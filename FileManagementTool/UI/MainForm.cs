// MainForm.cs
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        }

        private void InitializeDefaults()
        {
            // Set default text and states
            txtSourceFolder.Text = string.Empty;
            txtDestinationFolder.Text = string.Empty;
            txtConfigFile.Text = string.Empty;
            chkUseDefaultConfig.Checked = true;
            txtConfigFile.Enabled = false;
            btnBrowseConfig.Enabled = false;
            UpdateProgress(0, "Ready to organize files");
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

        private void btnBrowseConfig_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select configuration file";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.DefaultExt = "json";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtConfigFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void chkUseDefaultConfig_CheckedChanged(object sender, EventArgs e)
        {
            txtConfigFile.Enabled = !chkUseDefaultConfig.Checked;
            btnBrowseConfig.Enabled = !chkUseDefaultConfig.Checked;

            if (chkUseDefaultConfig.Checked)
            {
                txtConfigFile.Text = "Using default configuration";
            }
            else
            {
                txtConfigFile.Text = string.Empty;
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

            // Validate config file (if custom config is selected)
            if (!chkUseDefaultConfig.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtConfigFile.Text))
                {
                    errorMessage += "• Please select a configuration file.\n";
                    isValid = false;
                }
                else if (!System.IO.File.Exists(txtConfigFile.Text))
                {
                    errorMessage += "• Selected configuration file does not exist.\n";
                    isValid = false;
                }
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

            try
            {
                // Get parameters
                string sourcePath = txtSourceFolder.Text;
                string destinationPath = txtDestinationFolder.Text;
                string configPath = chkUseDefaultConfig.Checked ? null : txtConfigFile.Text;

                // TODO: Call the file organization logic
                // For now, simulate the process
                SimulateFileOrganization();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting file organization: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable controls
                SetControlsEnabled(true);
            }
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
            btnBrowseConfig.Enabled = enabled && !chkUseDefaultConfig.Checked;
            chkUseDefaultConfig.Enabled = enabled;
            btnStart.Enabled = enabled;

            // Update progress bar style
            progressBar.Style = enabled ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;

            if (!enabled)
            {
                lblStatus.Text = "Processing...";
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
            // TODO: Show error log
            MessageBox.Show("Error log feature will be implemented in the next phase.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}