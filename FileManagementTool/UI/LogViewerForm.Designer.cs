// LogViewerForm.Designer.cs
namespace FileManagementTool
{
    partial class LogViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewerForm));
            this.txtLogContent = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogContent
            // 
            this.txtLogContent.BackColor = System.Drawing.Color.White;
            this.txtLogContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogContent.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogContent.Location = new System.Drawing.Point(0, 0);
            this.txtLogContent.Multiline = true;
            this.txtLogContent.Name = "txtLogContent";
            this.txtLogContent.ReadOnly = true;
            this.txtLogContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogContent.Size = new System.Drawing.Size(784, 511);
            this.txtLogContent.TabIndex = 0;
            this.txtLogContent.WordWrap = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCopy);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 511);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(784, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(12, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(120, 30);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save As...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(652, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LogViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtLogContent);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "LogViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error Log Viewer";
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogContent;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}