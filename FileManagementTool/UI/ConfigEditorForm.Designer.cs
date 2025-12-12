// ConfigEditorForm.Designer.cs
namespace FileManagementTool
{
    partial class ConfigEditorForm
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
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblCategoriesTitle = new System.Windows.Forms.Label();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnRemoveCategory = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblEditorTitle = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.lblExtensions = new System.Windows.Forms.Label();
            this.pnlExtensions = new System.Windows.Forms.FlowLayoutPanel();
            this.panelExtensionInput = new System.Windows.Forms.Panel();
            this.btnAddExtension = new System.Windows.Forms.Button();
            this.lblExtensionError = new System.Windows.Forms.Label();
            this.lblEditorStatus = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtNewExtension = new System.Windows.Forms.TextBox();
            this.mainLayoutPanel.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelExtensionInput.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mainLayoutPanel.Controls.Add(this.panelLeft, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.panelRight, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.panelBottom, 0, 1);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(900, 650);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.lblCategoriesTitle);
            this.panelLeft.Controls.Add(this.lstCategories);
            this.panelLeft.Controls.Add(this.btnAddCategory);
            this.panelLeft.Controls.Add(this.btnRemoveCategory);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(3, 3);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.Size = new System.Drawing.Size(354, 546);
            this.panelLeft.TabIndex = 0;
            // 
            // lblCategoriesTitle
            // 
            this.lblCategoriesTitle.AutoSize = true;
            this.lblCategoriesTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCategoriesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblCategoriesTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCategoriesTitle.Name = "lblCategoriesTitle";
            this.lblCategoriesTitle.Size = new System.Drawing.Size(106, 25);
            this.lblCategoriesTitle.TabIndex = 0;
            this.lblCategoriesTitle.Text = "Categories";
            // 
            // lstCategories
            // 
            this.lstCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCategories.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.ItemHeight = 21;
            this.lstCategories.Location = new System.Drawing.Point(10, 40);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(332, 380);
            this.lstCategories.TabIndex = 1;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnAddCategory.FlatAppearance.BorderSize = 0;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(10, 450);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(332, 35);
            this.btnAddCategory.TabIndex = 2;
            this.btnAddCategory.Text = "+ Add New Category";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            // 
            // btnRemoveCategory
            // 
            this.btnRemoveCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnRemoveCategory.FlatAppearance.BorderSize = 0;
            this.btnRemoveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveCategory.ForeColor = System.Drawing.Color.White;
            this.btnRemoveCategory.Location = new System.Drawing.Point(10, 495);
            this.btnRemoveCategory.Name = "btnRemoveCategory";
            this.btnRemoveCategory.Size = new System.Drawing.Size(332, 30);
            this.btnRemoveCategory.TabIndex = 3;
            this.btnRemoveCategory.Text = "Remove Selected";
            this.btnRemoveCategory.UseVisualStyleBackColor = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.lblEditorTitle);
            this.panelRight.Controls.Add(this.lblCategoryName);
            this.panelRight.Controls.Add(this.txtCategoryName);
            this.panelRight.Controls.Add(this.lblFolderName);
            this.panelRight.Controls.Add(this.txtFolderName);
            this.panelRight.Controls.Add(this.lblExtensions);
            this.panelRight.Controls.Add(this.pnlExtensions);
            this.panelRight.Controls.Add(this.panelExtensionInput);
            this.panelRight.Controls.Add(this.lblEditorStatus);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(363, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(15);
            this.panelRight.Size = new System.Drawing.Size(534, 546);
            this.panelRight.TabIndex = 1;
            // 
            // lblEditorTitle
            // 
            this.lblEditorTitle.AutoSize = true;
            this.lblEditorTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEditorTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblEditorTitle.Location = new System.Drawing.Point(15, 15);
            this.lblEditorTitle.Name = "lblEditorTitle";
            this.lblEditorTitle.Size = new System.Drawing.Size(158, 25);
            this.lblEditorTitle.TabIndex = 0;
            this.lblEditorTitle.Text = "Category Details";
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoryName.Location = new System.Drawing.Point(15, 60);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(116, 20);
            this.lblCategoryName.TabIndex = 1;
            this.lblCategoryName.Text = "Category Name:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCategoryName.Location = new System.Drawing.Point(115, 57);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(402, 27);
            this.txtCategoryName.TabIndex = 2;
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFolderName.Location = new System.Drawing.Point(15, 100);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(98, 20);
            this.lblFolderName.TabIndex = 3;
            this.lblFolderName.Text = "Folder Name:";
            // 
            // txtFolderName
            // 
            this.txtFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFolderName.Location = new System.Drawing.Point(115, 97);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(402, 27);
            this.txtFolderName.TabIndex = 4;
            // 
            // lblExtensions
            // 
            this.lblExtensions.AutoSize = true;
            this.lblExtensions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExtensions.Location = new System.Drawing.Point(15, 140);
            this.lblExtensions.Name = "lblExtensions";
            this.lblExtensions.Size = new System.Drawing.Size(108, 20);
            this.lblExtensions.TabIndex = 5;
            this.lblExtensions.Text = "File Extensions:";
            // 
            // pnlExtensions
            // 
            this.pnlExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExtensions.AutoScroll = true;
            this.pnlExtensions.BackColor = System.Drawing.Color.White;
            this.pnlExtensions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExtensions.Location = new System.Drawing.Point(115, 140);
            this.pnlExtensions.Name = "pnlExtensions";
            this.pnlExtensions.Padding = new System.Windows.Forms.Padding(5);
            this.pnlExtensions.Size = new System.Drawing.Size(402, 250);
            this.pnlExtensions.TabIndex = 6;
            // 
            // panelExtensionInput
            // 
            this.panelExtensionInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExtensionInput.Controls.Add(this.txtNewExtension);
            this.panelExtensionInput.Controls.Add(this.btnAddExtension);
            this.panelExtensionInput.Controls.Add(this.lblExtensionError);
            this.panelExtensionInput.Location = new System.Drawing.Point(115, 400);
            this.panelExtensionInput.Name = "panelExtensionInput";
            this.panelExtensionInput.Size = new System.Drawing.Size(402, 35);
            this.panelExtensionInput.TabIndex = 7;
            // 
            // btnAddExtension
            // 
            this.btnAddExtension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddExtension.FlatAppearance.BorderSize = 0;
            this.btnAddExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExtension.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddExtension.ForeColor = System.Drawing.Color.White;
            this.btnAddExtension.Location = new System.Drawing.Point(110, 5);
            this.btnAddExtension.Name = "btnAddExtension";
            this.btnAddExtension.Size = new System.Drawing.Size(100, 23);
            this.btnAddExtension.TabIndex = 1;
            this.btnAddExtension.Text = "Add";
            this.btnAddExtension.UseVisualStyleBackColor = false;
            // 
            // lblExtensionError
            // 
            this.lblExtensionError.AutoSize = true;
            this.lblExtensionError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblExtensionError.ForeColor = System.Drawing.Color.Red;
            this.lblExtensionError.Location = new System.Drawing.Point(220, 10);
            this.lblExtensionError.Name = "lblExtensionError";
            this.lblExtensionError.Size = new System.Drawing.Size(0, 19);
            this.lblExtensionError.TabIndex = 2;
            // 
            // lblEditorStatus
            // 
            this.lblEditorStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEditorStatus.AutoSize = true;
            this.lblEditorStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEditorStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblEditorStatus.Location = new System.Drawing.Point(15, 510);
            this.lblEditorStatus.Name = "lblEditorStatus";
            this.lblEditorStatus.Size = new System.Drawing.Size(150, 20);
            this.lblEditorStatus.TabIndex = 8;
            this.lblEditorStatus.Text = "No category selected";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.mainLayoutPanel.SetColumnSpan(this.panelBottom, 2);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Controls.Add(this.btnReset);
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(3, 555);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(894, 92);
            this.panelBottom.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(380, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(510, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // txtNewExtension
            // 
            this.txtNewExtension.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewExtension.Location = new System.Drawing.Point(3, 3);
            this.txtNewExtension.Name = "txtNewExtension";
            this.txtNewExtension.Size = new System.Drawing.Size(100, 27);
            this.txtNewExtension.TabIndex = 0;
            // 
            // ConfigEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.mainLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ConfigEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration Editor";
            this.mainLayoutPanel.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelExtensionInput.ResumeLayout(false);
            this.panelExtensionInput.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblCategoriesTitle;
        private System.Windows.Forms.ListBox lstCategories;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnRemoveCategory;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblEditorTitle;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label lblExtensions;
        private System.Windows.Forms.FlowLayoutPanel pnlExtensions;
        private System.Windows.Forms.Panel panelExtensionInput;
        private System.Windows.Forms.Button btnAddExtension;
        private System.Windows.Forms.Label lblExtensionError;
        private System.Windows.Forms.Label lblEditorStatus;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNewExtension;
    }
}