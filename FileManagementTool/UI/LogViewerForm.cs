// LogViewerForm.cs
using System;
using System.IO;
using System.Windows.Forms;

namespace FileManagementTool
{
    public partial class LogViewerForm : Form
    {
        public LogViewerForm(string logContent)
        {
            InitializeComponent();
            txtLogContent.Text = logContent;

            // Scroll to top
            txtLogContent.SelectionStart = 0;
            txtLogContent.SelectionLength = 0;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtLogContent.Text);
                MessageBox.Show("Log copied to clipboard.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error copying to clipboard: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Save Log File";
                saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveDialog.DefaultExt = "txt";
                saveDialog.FileName = $"FileManagementLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveDialog.FileName, txtLogContent.Text);
                        MessageBox.Show($"Log saved to:\n{saveDialog.FileName}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Allow Ctrl+A to select all text
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.A))
            {
                txtLogContent.SelectAll();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}