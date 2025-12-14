// ConfigEditorForm.cs (COMPLETE VERSION)
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileManagementTool.Configuration;
using FileManagementTool.Models;

namespace FileManagementTool
{
    public partial class ConfigEditorForm : Form
    {
        private List<Category> categories;
        private Category selectedCategory = null;
        private bool hasChanges = false;
        private ConfigurationManager configManager;

        public ConfigEditorForm()
        {
            InitializeComponent();

            // Initialize ConfigurationManager
            configManager = new ConfigurationManager();

            // Load configuration
            if (!configManager.LoadConfiguration())
            {
                MessageBox.Show("Failed to load configuration. Using defaults.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            categories = configManager.GetCategories();

            SetupInitialState();

            // Populate the list
            RefreshCategoryList();

            // Select first category if available
            if (categories.Count > 0)
            {
                lstCategories.SelectedIndex = 0;
            }

            UpdateUI();
        }

        private void SetupInitialState()
        {
            // Center buttons in bottom panel
            CenterBottomButtons();


            txtNewExtension.Text = "";

            UpdateButtonStates();

            // Hide error label
            lblExtensionError.Visible = false;
        }

        private void CenterBottomButtons()
        {
            // Center the buttons horizontally in the bottom panel
            int buttonWidth = 120;
            int buttonHeight = 40;
            int spacing = 15;
            int totalWidth = (buttonWidth * 3) + (spacing * 2);

            int startX = (panelBottom.Width - totalWidth) / 2;
            int startY = (panelBottom.Height - buttonHeight) / 2;

            btnSave.Location = new Point(startX, startY);
            btnReset.Location = new Point(startX + buttonWidth + spacing, startY);
            btnClose.Location = new Point(startX + (buttonWidth + spacing) * 2, startY);
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = selectedCategory != null;

            btnRemoveCategory.Enabled = hasSelection && categories.Count > 1;
            txtCategoryName.Enabled = hasSelection;
            txtFolderName.Enabled = hasSelection;
            txtNewExtension.Enabled = hasSelection;
            btnAddExtension.Enabled = hasSelection;
            btnSave.Enabled = hasChanges;
        }

        private void RefreshCategoryList()
        {
            lstCategories.DataSource = null;
            lstCategories.DataSource = categories;
            lstCategories.DisplayMember = "Name";
        }

        private void SelectCategory(Category category)
        {
            selectedCategory = category;

            if (category != null)
            {
                txtCategoryName.Text = category.Name;
                txtFolderName.Text = category.FolderName;
                RefreshExtensions();

                // Update status
                UpdateStatusLabel();

                // Highlight in list
                lstCategories.SelectedItem = category;
            }
            else
            {
                ClearEditor();
            }

            UpdateButtonStates();
        }

        private void ClearEditor()
        {
            txtCategoryName.Clear();
            txtFolderName.Clear();
            pnlExtensions.Controls.Clear();
            lblEditorStatus.Text = "No category selected";
            lblEditorStatus.ForeColor = Color.Gray;
        }

        private void RefreshExtensions()
        {
            pnlExtensions.Controls.Clear();

            if (selectedCategory == null) return;

            foreach (var extension in selectedCategory.Extensions)
            {
                AddExtensionChip(extension);
            }

            UpdateStatusLabel();
        }

        private void AddExtensionChip(string extension)
        {
            var chipPanel = new Panel
            {
                Size = new Size(70, 30),
                Margin = new Padding(3),
                BackColor = Color.FromArgb(233, 236, 239),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            var lblExtension = new Label
            {
                Text = extension,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 37, 41),
                Location = new Point(5, 7),
                AutoSize = true
            };

            // Add click to remove
            chipPanel.Click += (s, e) =>
            {
                if (selectedCategory != null && MessageBox.Show(
                    $"Remove extension '{extension}'?",
                    "Remove Extension",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    selectedCategory.Extensions.Remove(extension);
                    RefreshExtensions();
                    hasChanges = true;
                    UpdateUI();
                }
            };

            chipPanel.Controls.Add(lblExtension);
            pnlExtensions.Controls.Add(chipPanel);
        }

        private void UpdateStatusLabel()
        {
            if (selectedCategory == null)
            {
                lblEditorStatus.Text = "No category selected";
                lblEditorStatus.ForeColor = Color.Gray;
                return;
            }

            int count = selectedCategory.Extensions.Count;
            string plural = count == 1 ? "" : "s";
            lblEditorStatus.Text = $"{count} extension{plural}";

            // Validate
            bool isValid = ValidateCategory(selectedCategory);
            if (!isValid)
            {
                lblEditorStatus.Text += " (Invalid)";
                lblEditorStatus.ForeColor = Color.Red;
            }
            else
            {
                lblEditorStatus.ForeColor = Color.Gray;
            }
        }

        private bool ValidateCategory(Category category)
        {
            return !string.IsNullOrWhiteSpace(category.Name) &&
                   !string.IsNullOrWhiteSpace(category.FolderName) &&
                   category.Extensions.Count > 0;
        }

        private bool ValidateAllCategories()
        {
            if (categories.Count == 0)
            {
                MessageBox.Show("At least one category is required.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check for empty categories
            foreach (var category in categories)
            {
                if (!ValidateCategory(category))
                {
                    MessageBox.Show($"Category '{category.Name}' is invalid.\n\n" +
                        "Please check:\n" +
                        "• Category name is not empty\n" +
                        "• Folder name is not empty\n" +
                        "• At least one extension is specified",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void UpdateUI()
        {
            // Update title with change indicator
            string title = "Configuration Editor";
            if (hasChanges) title += " *";
            this.Text = title;

            // Update button states
            UpdateButtonStates();

            // Update status
            UpdateStatusLabel();
        }

        // Event Handlers
        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategory = lstCategories.SelectedItem as Category;

            if (selectedCategory != null)
            {
                txtCategoryName.Text = selectedCategory.Name;
                txtFolderName.Text = selectedCategory.FolderName;
                RefreshExtensions();
            }
            else
            {
                txtCategoryName.Clear();
                txtFolderName.Clear();
                pnlExtensions.Controls.Clear();
            }

            UpdateUI();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var newCategory = new Category
            {
                Name = "New Category",
                FolderName = "NewCategory",
                Extensions = new List<string> { ".txt" }
            };

            categories.Add(newCategory);
            RefreshCategoryList();
            lstCategories.SelectedItem = newCategory;
            hasChanges = true;
            UpdateUI();

            // Focus on name for editing
            txtCategoryName.Focus();
            txtCategoryName.SelectAll();
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null) return;

            if (categories.Count <= 1)
            {
                MessageBox.Show("You must have at least one category.",
                    "Cannot Remove", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                $"Remove category '{selectedCategory.Name}'?",
                "Remove Category",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                categories.Remove(selectedCategory);
                RefreshCategoryList();

                // Select another category
                if (categories.Count > 0)
                {
                    lstCategories.SelectedIndex = 0;
                }
                else
                {
                    selectedCategory = null;
                }

                hasChanges = true;
                UpdateUI();
            }
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            if (selectedCategory != null)
            {
                selectedCategory.Name = txtCategoryName.Text;
                hasChanges = true;

                // Instead of refreshing the entire list, update just this item
                // This prevents the SelectedIndexChanged event from firing
                int index = categories.IndexOf(selectedCategory);
                if (index >= 0)
                {
                    // Update the list item directly without changing DataSource
                    // This is a workaround for Windows Forms ListBox
                    var items = lstCategories.Items;
                    if (index < items.Count)
                    {
                        // We can't directly update the item in a bound listbox
                        // So we'll disable the event, refresh, and reselect
                        lstCategories.SelectedIndexChanged -= lstCategories_SelectedIndexChanged;
                        try
                        {
                            lstCategories.DataSource = null;
                            lstCategories.DataSource = categories;
                            lstCategories.DisplayMember = "Name";
                            lstCategories.SelectedIndex = index;
                        }
                        finally
                        {
                            lstCategories.SelectedIndexChanged += lstCategories_SelectedIndexChanged;
                        }
                    }
                }

                UpdateUI();
            }
        }

        private void txtFolderName_TextChanged(object sender, EventArgs e)
        {
            if (selectedCategory != null)
            {
                selectedCategory.FolderName = txtFolderName.Text;
                hasChanges = true;
                UpdateUI();
            }
        }

        private void btnAddExtension_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null) return;

            string extension = txtNewExtension.Text.Trim();

            if (string.IsNullOrWhiteSpace(extension))
            {
                MessageBox.Show("Please enter an extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure it starts with dot
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            // Check for duplicates
            if (selectedCategory.Extensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
            {
                MessageBox.Show("Extension already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the extension
            selectedCategory.Extensions.Add(extension);
            RefreshExtensions();
            txtNewExtension.Clear();
            hasChanges = true;
            UpdateUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate all categories before saving
            if (!ValidateAllCategories())
            {
                return;
            }

            // Save using ConfigurationManager
            if (configManager.SaveConfiguration(categories))
            {
                hasChanges = false;
                MessageBox.Show("Configuration saved successfully!",
                    "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateUI();
            }
            else
            {
                MessageBox.Show("Error saving configuration.",
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!hasChanges && categories.Count == 6) // 6 is default count
            {
                MessageBox.Show("Configuration is already at default settings.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                "Reset all categories to default settings?\n\n" +
                "This will replace all your current categories with the default ones.",
                "Reset to Default",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                categories = configManager.GetDefaultCategories();
                RefreshCategoryList();

                if (categories.Count > 0)
                {
                    lstCategories.SelectedIndex = 0;
                }

                hasChanges = true;
                UpdateUI();

                MessageBox.Show("Configuration reset to defaults. Click Save to apply changes.",
                    "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (hasChanges)
            {
                var result = MessageBox.Show("You have unsaved changes. Close anyway?",
                    "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            this.Close();
        }

        private void txtNewExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAddExtension_Click(sender, e);
                e.Handled = true;
            }
        }

        private void panelBottom_Resize(object sender, EventArgs e)
        {
            CenterBottomButtons();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCategoryName_Click(object sender, EventArgs e)
        {

        }
    }
}