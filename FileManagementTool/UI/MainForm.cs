using FileManagementTool.FileManagement;
using FileManagementTool.FolderManagement;
using FileManagementTool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FileManagementTool.ErrorHandling;


namespace FileManagementTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize default settings
            InitializeDefaults();

            // Update form for better maximized appearance
            UpdateFormForMaximizedState();
        }

        private void InitializeDefaults()
        {
            // Set default text and states
            txtSourceFolder.Text = string.Empty;
            txtDestinationFolder.Text = string.Empty;

            // Configuration defaults
            chkUseDefaultConfig.Checked = true;
            UpdateConfigStatus();

            // Update progress
            UpdateProgress(0, "Ready to organize files");

            // Set initial button states
            UpdateButtonStates();
        }

        private void UpdateFormForMaximizedState()
        {
            // Make sure controls anchor properly
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Set minimum size to ensure good layout
            this.MinimumSize = new System.Drawing.Size(900, 600);
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select source folder containing files to organize";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFolder.Text = folderDialog.SelectedPath;
                    ValidateInputs();
                }
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select destination folder (optional - will create timestamped folder if not specified)";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDestinationFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void chkUseDefaultConfig_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConfigStatus();
            UpdateButtonStates();
            ValidateInputs();
        }

        private void btnEditConfig_Click(object sender, EventArgs e)
        {
            // Open the configuration editor
            using (var editor = new ConfigEditorForm())
            {
                editor.ShowDialog();

                // After editor closes, update status
                UpdateConfigStatus();
            }
        }

        private void btnResetConfig_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Reset configuration to defaults?\n\n" +
                "This will restore the original file categories and extensions.",
                "Reset Configuration",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // TODO: Implement actual reset logic
                // For now, just update the status
                chkUseDefaultConfig.Checked = true;
                UpdateConfigStatus();

                MessageBox.Show("Configuration has been reset to defaults.",
                    "Reset Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void UpdateConfigStatus()
        {
            if (chkUseDefaultConfig.Checked)
            {
                lblConfigStatus.Text = "Using default configuration";
                lblConfigStatus.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            }
            else
            {
                lblConfigStatus.Text = "Using custom configuration";
                lblConfigStatus.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50); // Green
            }
        }

        private void UpdateButtonStates()
        {
            // Enable/disable Edit and Reset buttons based on checkbox
            bool useCustomConfig = !chkUseDefaultConfig.Checked;

            btnEditConfig.Enabled = true; // Always enabled for now
            btnResetConfig.Enabled = true; // Always enabled

            // Change button appearance based on state
            if (useCustomConfig)
            {
                btnEditConfig.BackColor = System.Drawing.Color.FromArgb(46, 125, 50); // Green
                btnEditConfig.Text = "Edit Custom Configuration";
            }
            else
            {
                btnEditConfig.BackColor = System.Drawing.Color.FromArgb(0, 102, 204); // Blue
                btnEditConfig.Text = "Edit Configuration";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                StartFileOrganization();
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            string errorMessage = string.Empty;

            // Validate source folder
            if (string.IsNullOrWhiteSpace(txtSourceFolder.Text))
            {
                errorMessage += "• Please select a source folder.\n";
                isValid = false;
            }
            else if (!System.IO.Directory.Exists(txtSourceFolder.Text))
            {
                errorMessage += "• Selected source folder does not exist.\n";
                isValid = false;
            }

            // Validate destination folder (if provided)
            if (!string.IsNullOrWhiteSpace(txtDestinationFolder.Text) &&
                !System.IO.Directory.Exists(txtDestinationFolder.Text))
            {
                errorMessage += "• Selected destination folder does not exist.\n";
                isValid = false;
            }

            // Update UI state
            btnStart.Enabled = isValid;

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private void StartFileOrganization()
        {
            // Disable controls during processing
            SetControlsEnabled(false);

            // Reset progress
            UpdateProgress(0, "Starting file organization...");

            // Get error logger instance
            var errorLogger = ErrorLogger.Instance;
            errorLogger.LogOperation("File Organization Started");

            try
            {
                // Get parameters
                string sourcePath = txtSourceFolder.Text;
                string destinationPath = GetDestinationPath();
                bool useDefaultConfig = chkUseDefaultConfig.Checked;

                errorLogger.LogInfo($"Source: {sourcePath}");
                errorLogger.LogInfo($"Destination: {destinationPath}");
                errorLogger.LogInfo($"Using default config: {useDefaultConfig}");

                // Step 1: Load configuration
                UpdateProgress(10, "Loading configuration...");
                errorLogger.LogOperation("Loading Configuration");

                var categories = LoadConfiguration(useDefaultConfig);

                if (categories.Count == 0)
                {
                    string errorMsg = "No categories found in configuration.";
                    errorLogger.LogError(errorMsg);
                    MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                errorLogger.LogInfo($"Loaded {categories.Count} categories");

                // Step 2: Scan files
                UpdateProgress(20, "Scanning source folder...");
                errorLogger.LogOperation("Scanning Files");

                var fileScanner = new FileScanner();
                List<ScannedFile> files;

                try
                {
                    files = fileScanner.ScanFiles(sourcePath);
                    errorLogger.LogInfo($"Found {files.Count} files in source folder");
                }
                catch (Exception ex)
                {
                    errorLogger.LogError("Failed to scan files", ex);
                    MessageBox.Show($"Error scanning files:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (files.Count == 0)
                {
                    errorLogger.LogWarning("No files found in source folder");
                    MessageBox.Show("No files found in the source folder.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateProgress(100, "No files found");
                    return;
                }

                // Step 3: Categorize files
                UpdateProgress(40, "Categorizing files...");
                errorLogger.LogOperation("Categorizing Files");

                var categoryManager = new CategoryManager(categories);
                var categorizedFiles = categoryManager.CategorizeFiles(files);

                // Log category breakdown
                string categoryInfo = "Files by category:\n";
                foreach (var category in categorizedFiles)
                {
                    categoryInfo += $"{category.Key}: {category.Value.Count} files\n";
                    errorLogger.LogInfo($"{category.Key}: {category.Value.Count} files");
                }
                lblStatus.Text = categoryInfo;

                // Step 4: Organize files
                UpdateProgress(60, "Organizing files...");
                errorLogger.LogOperation("Organizing Files");

                var fileOrganizer = new FileOrganizer();

                // Subscribe to progress events
                fileOrganizer.FileProgress += FileOrganizer_FileProgress;
                fileOrganizer.OperationProgress += FileOrganizer_OperationProgress;

                // Also log file operations
                fileOrganizer.FileProgress += (sender, e) =>
                {
                    errorLogger.LogFileOperation(e.FileName, "File Copy", e.IsSuccess, e.Message);
                };

                // Start organization
                var result = fileOrganizer.OrganizeFiles(files, categorizedFiles, destinationPath, categoryManager);

                // Step 5: Show results
                UpdateProgress(100, "File organization completed!");
                errorLogger.LogOperation("File Organization Completed",
                    $"Total: {result.TotalFiles}, Success: {result.SuccessfulFiles}, Failed: {result.FailedFiles}");

                if (result.IsSuccess)
                {
                    string successMessage = $"File organization completed!\n\n" +
                                           $"Total files: {result.TotalFiles}\n" +
                                           $"Successfully processed: {result.SuccessfulFiles}\n" +
                                           $"Failed: {result.FailedFiles}\n\n" +
                                           $"Files organized to:\n{destinationPath}\n\n" +
                                           $"Click OK to open the folder.";

                    var dialogResult = MessageBox.Show(successMessage,
                        "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.OK && Directory.Exists(destinationPath))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", destinationPath);
                    }
                }
                else
                {
                    MessageBox.Show($"File organization completed with issues:\n{result.Message}",
                        "Completed with Issues", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Show log summary if there were errors
                if (result.FailedFiles > 0)
                {
                    string logSummary = errorLogger.GetLogSummary();
                    lblStatus.Text += $"\n\n{logSummary}";
                }
            }
            catch (Exception ex)
            {
                errorLogger.LogError("Fatal error during file organization", ex);
                MessageBox.Show($"Error during file organization:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable controls
                SetControlsEnabled(true);
            }
        }


        private string GetDestinationPath()
        {
            // If user provided a destination, use it
            if (!string.IsNullOrWhiteSpace(txtDestinationFolder.Text))
            {
                return txtDestinationFolder.Text;
            }

            // If no destination provided, create on Desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string folderName = $"Organized_Files_{timestamp}";
            string fullPath = Path.Combine(desktopPath, folderName);

            // Create the folder
            Directory.CreateDirectory(fullPath);

            return fullPath;
        }

        private List<Models.Category> LoadConfiguration(bool useDefaultConfig)
        {
            if (useDefaultConfig)
            {
                // Return default categories
                return new List<Models.Category>
        {
            new Models.Category("Documents", "Documents", ".txt", ".doc", ".docx", ".pdf", ".xlsx", ".pptx", ".rtf"),
            new Models.Category("Images", "Images", ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".svg"),
            new Models.Category("Videos", "Videos", ".mp4", ".avi", ".mov", ".wmv", ".mkv", ".flv"),
            new Models.Category("Audio", "Audio", ".mp3", ".wav", ".aac", ".flac", ".m4a", ".ogg"),
            new Models.Category("Archives", "Archives", ".zip", ".rar", ".7z", ".tar", ".gz"),
            new Models.Category("Executables", "Executables", ".exe", ".msi", ".bat", ".cmd")
        };
            }
            else
            {
                // Load from config file
                string configPath = GetConfigPath();

                if (File.Exists(configPath))
                {
                    try
                    {
                        string json = File.ReadAllText(configPath);
                        return System.Text.Json.JsonSerializer.Deserialize<List<Models.Category>>(json);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading configuration file:\n{ex.Message}\n\nUsing default configuration instead.",
                            "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Fall back to default
                        return LoadConfiguration(true);
                    }
                }
                else
                {
                    MessageBox.Show("Configuration file not found. Using default configuration.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return LoadConfiguration(true);
                }
            }
        }

        private string GetConfigPath()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appData, "FileManagementTool", "categories.json");
        }

        // Event handlers for progress updates
        private void FileOrganizer_FileProgress(object sender, FileProgressEventArgs e)
        {
            UpdateProgress(60 + (int)((e.CurrentFile * 40.0) / e.TotalFiles),
                          $"{e.FileName} - {(e.IsSuccess ? "Success" : "Failed")}");
        }

        private void FileOrganizer_OperationProgress(object sender, OperationProgressEventArgs e)
        {
            UpdateProgress(e.Percentage, e.Operation);
        }

        private void SimulateFileOrganization()
        {
            // This is a placeholder - will be replaced with actual implementation
            UpdateProgress(10, "Loading configuration...");
            System.Threading.Thread.Sleep(500);

            UpdateProgress(30, "Scanning source folder...");
            System.Threading.Thread.Sleep(1000);

            UpdateProgress(60, "Categorizing files...");
            System.Threading.Thread.Sleep(500);

            UpdateProgress(80, "Organizing files...");
            System.Threading.Thread.Sleep(1000);

            UpdateProgress(100, "File organization completed!");

            MessageBox.Show("File organization completed successfully!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateProgress(int percentage, string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(percentage, status)));
                return;
            }

            progressBar.Value = Math.Min(Math.Max(percentage, 0), 100);
            lblStatus.Text = status;

            if (percentage == 100)
            {
                progressBar.Style = ProgressBarStyle.Blocks;
            }
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnBrowseSource.Enabled = enabled;
            btnBrowseDestination.Enabled = enabled;
            btnEditConfig.Enabled = enabled;
            btnResetConfig.Enabled = enabled;
            chkUseDefaultConfig.Enabled = enabled;
            btnStart.Enabled = enabled && ValidateInputs();
            btnCancel.Enabled = !enabled;

            // Update progress bar style
            progressBar.Style = enabled ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;

            if (!enabled)
            {
                lblStatus.Text = "Processing...";
            }
            else
            {
                UpdateConfigStatus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // TODO: Implement cancellation logic
            UpdateProgress(0, "Operation cancelled");
            SetControlsEnabled(true);
        }

        private void lnkShowLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var errorLogger = ErrorLogger.Instance;
                string logContent = errorLogger.GetFullLog();

                // Show in log viewer form
                using (var logViewer = new LogViewerForm(logContent))
                {
                    logViewer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing log: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}