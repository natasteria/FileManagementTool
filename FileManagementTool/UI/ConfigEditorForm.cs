// ConfigEditorForm.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileManagementTool.Models;

namespace FileManagementTool
{
    public partial class ConfigEditorForm : Form
    {
        private List<Category> categories = new List<Category>();
        private Category selectedCategory = null;
        private bool hasChanges = false;

        public ConfigEditorForm()
        {
            InitializeComponent();
            SetupInitialState();
        }

        private void SetupInitialState()
        {
            // Load some sample categories for testing
            LoadSampleCategories();

            // Populate the list
            RefreshCategoryList();

            // Select first category if exists
            if (categories.Count > 0)
            {
                lstCategories.SelectedIndex = 0;
            }

            // Update UI
            UpdateUI();
        }

        private void LoadSampleCategories()
        {
            categories = new List<Category>
            {
                new Category("Documents", "Documents", ".txt", ".doc", ".pdf"),
                new Category("Images", "Images", ".jpg", ".png", ".gif"),
                new Category("Videos", "Videos", ".mp4", ".avi", ".mov")
            };
        }

        private void RefreshCategoryList()
        {
            lstCategories.DataSource = null;
            lstCategories.DataSource = categories;
        }

        private void UpdateUI()
        {
            // Enable/disable buttons based on selection
            bool hasSelection = selectedCategory != null;

            btnRemoveCategory.Enabled = hasSelection && categories.Count > 1;
            txtCategoryName.Enabled = hasSelection;
            txtFolderName.Enabled = hasSelection;
            txtNewExtension.Enabled = hasSelection;
            btnAddExtension.Enabled = hasSelection;
            btnSave.Enabled = hasChanges;

            // Update status
            if (selectedCategory != null)
            {
                lblEditorStatus.Text = $"{selectedCategory.Extensions.Count} extensions";
            }
            else
            {
                lblEditorStatus.Text = "No category selected";
            }
        }

        private void RefreshExtensions()
        {
            pnlExtensions.Controls.Clear();

            if (selectedCategory == null) return;

            foreach (var extension in selectedCategory.Extensions)
            {
                AddExtensionChip(extension);
            }
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
                RefreshCategoryList();
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
            MessageBox.Show("Save functionality will be implemented next.",
                "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // For now, just mark as saved
            hasChanges = false;
            UpdateUI();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset to default categories?",
                "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSampleCategories();
                RefreshCategoryList();

                if (categories.Count > 0)
                {
                    lstCategories.SelectedIndex = 0;
                }

                hasChanges = true;
                UpdateUI();
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
    }
}