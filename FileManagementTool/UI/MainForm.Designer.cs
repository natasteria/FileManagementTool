namespace FileManagementTool
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.TextBox txtSourceFolder;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Label lblDestinationHint;
        private System.Windows.Forms.GroupBox gbConfiguration;
        private System.Windows.Forms.CheckBox chkUseDefaultConfig;
        private System.Windows.Forms.Panel panelConfigButtons;
        private System.Windows.Forms.Button btnEditConfig;
        private System.Windows.Forms.Button btnResetConfig;
        private System.Windows.Forms.Label lblConfigStatus;
        private System.Windows.Forms.Label lblConfigHint;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel lnkShowLog;
        private System.Windows.Forms.Label lblErrorLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gbConfiguration = new System.Windows.Forms.GroupBox();
            this.lblConfigStatus = new System.Windows.Forms.Label();
            this.panelConfigButtons = new System.Windows.Forms.Panel();
            this.btnResetConfig = new System.Windows.Forms.Button();
            this.btnEditConfig = new System.Windows.Forms.Button();
            this.lblConfigHint = new System.Windows.Forms.Label();
            this.chkUseDefaultConfig = new System.Windows.Forms.CheckBox();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.lblDestinationHint = new System.Windows.Forms.Label();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.lblErrorLog = new System.Windows.Forms.Label();
            this.lnkShowLog = new System.Windows.Forms.LinkLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.gbConfiguration.SuspendLayout();
            this.panelConfigButtons.SuspendLayout();
            this.gbDestination.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblDescription);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelHeader.Size = new System.Drawing.Size(974, 100);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblDescription.Location = new System.Drawing.Point(30, 61);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(812, 23);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Organize files in a folder based on their extensions. Files are categorized accor" +
    "ding to configuration rules.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(331, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "File Management Tool";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.gbConfiguration);
            this.panelMain.Controls.Add(this.gbDestination);
            this.panelMain.Controls.Add(this.gbSource);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(3, 109);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(974, 296);
            this.panelMain.TabIndex = 1;
            // 
            // gbConfiguration
            // 
            this.gbConfiguration.Controls.Add(this.lblConfigStatus);
            this.gbConfiguration.Controls.Add(this.panelConfigButtons);
            this.gbConfiguration.Controls.Add(this.lblConfigHint);
            this.gbConfiguration.Controls.Add(this.chkUseDefaultConfig);
            this.gbConfiguration.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConfiguration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConfiguration.Location = new System.Drawing.Point(30, 240);
            this.gbConfiguration.Name = "gbConfiguration";
            this.gbConfiguration.Size = new System.Drawing.Size(914, 100);
            this.gbConfiguration.TabIndex = 2;
            this.gbConfiguration.TabStop = false;
            this.gbConfiguration.Text = "Configuration";
            // 
            // lblConfigStatus
            // 
            this.lblConfigStatus.AutoSize = true;
            this.lblConfigStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblConfigStatus.Location = new System.Drawing.Point(20, 70);
            this.lblConfigStatus.Name = "lblConfigStatus";
            this.lblConfigStatus.Size = new System.Drawing.Size(205, 20);
            this.lblConfigStatus.TabIndex = 5;
            this.lblConfigStatus.Text = "Using default configuration file";
            // 
            // panelConfigButtons
            // 
            this.panelConfigButtons.Controls.Add(this.btnResetConfig);
            this.panelConfigButtons.Controls.Add(this.btnEditConfig);
            this.panelConfigButtons.Location = new System.Drawing.Point(200, 25);
            this.panelConfigButtons.Name = "panelConfigButtons";
            this.panelConfigButtons.Size = new System.Drawing.Size(300, 35);
            this.panelConfigButtons.TabIndex = 4;
            // 
            // btnResetConfig
            // 
            this.btnResetConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnResetConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnResetConfig.Location = new System.Drawing.Point(155, 0);
            this.btnResetConfig.Name = "btnResetConfig";
            this.btnResetConfig.Size = new System.Drawing.Size(140, 35);
            this.btnResetConfig.TabIndex = 2;
            this.btnResetConfig.Text = "Reset to Default";
            this.btnResetConfig.UseVisualStyleBackColor = false;
            this.btnResetConfig.Click += new System.EventHandler(this.btnResetConfig_Click);
            // 
            // btnEditConfig
            // 
            this.btnEditConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnEditConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditConfig.ForeColor = System.Drawing.Color.White;
            this.btnEditConfig.Location = new System.Drawing.Point(0, 0);
            this.btnEditConfig.Name = "btnEditConfig";
            this.btnEditConfig.Size = new System.Drawing.Size(140, 35);
            this.btnEditConfig.TabIndex = 1;
            this.btnEditConfig.Text = "Edit Configuration";
            this.btnEditConfig.UseVisualStyleBackColor = false;
            this.btnEditConfig.Click += new System.EventHandler(this.btnEditConfig_Click);
            // 
            // lblConfigHint
            // 
            this.lblConfigHint.AutoSize = true;
            this.lblConfigHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigHint.ForeColor = System.Drawing.Color.Gray;
            this.lblConfigHint.Location = new System.Drawing.Point(200, 70);
            this.lblConfigHint.Name = "lblConfigHint";
            this.lblConfigHint.Size = new System.Drawing.Size(789, 19);
            this.lblConfigHint.TabIndex = 3;
            this.lblConfigHint.Text = "Customize file categories and extensions. Click \'Edit Configuration\' to modify se" +
    "ttings or \'Reset to Default\' to restore defaults.";
            // 
            // chkUseDefaultConfig
            // 
            this.chkUseDefaultConfig.AutoSize = true;
            this.chkUseDefaultConfig.Checked = true;
            this.chkUseDefaultConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultConfig.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseDefaultConfig.Location = new System.Drawing.Point(20, 30);
            this.chkUseDefaultConfig.Name = "chkUseDefaultConfig";
            this.chkUseDefaultConfig.Size = new System.Drawing.Size(225, 27);
            this.chkUseDefaultConfig.TabIndex = 0;
            this.chkUseDefaultConfig.Text = "Use default configuration";
            this.chkUseDefaultConfig.UseVisualStyleBackColor = true;
            this.chkUseDefaultConfig.CheckedChanged += new System.EventHandler(this.chkUseDefaultConfig_CheckedChanged);
            // 
            // gbDestination
            // 
            this.gbDestination.Controls.Add(this.lblDestinationHint);
            this.gbDestination.Controls.Add(this.btnBrowseDestination);
            this.gbDestination.Controls.Add(this.txtDestinationFolder);
            this.gbDestination.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDestination.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDestination.Location = new System.Drawing.Point(30, 120);
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.Size = new System.Drawing.Size(914, 120);
            this.gbDestination.TabIndex = 1;
            this.gbDestination.TabStop = false;
            this.gbDestination.Text = "Destination Folder (Optional)";
            // 
            // lblDestinationHint
            // 
            this.lblDestinationHint.AutoSize = true;
            this.lblDestinationHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinationHint.ForeColor = System.Drawing.Color.Gray;
            this.lblDestinationHint.Location = new System.Drawing.Point(20, 70);
            this.lblDestinationHint.Name = "lblDestinationHint";
            this.lblDestinationHint.Size = new System.Drawing.Size(427, 19);
            this.lblDestinationHint.TabIndex = 2;
            this.lblDestinationHint.Text = "If not specified, a timestamped folder will be created automatically";
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDestination.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDestination.Location = new System.Drawing.Point(784, 35);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(120, 23);
            this.btnBrowseDestination.TabIndex = 1;
            this.btnBrowseDestination.Text = "Browse...";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinationFolder.Location = new System.Drawing.Point(20, 35);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.ReadOnly = true;
            this.txtDestinationFolder.Size = new System.Drawing.Size(758, 27);
            this.txtDestinationFolder.TabIndex = 0;
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.btnBrowseSource);
            this.gbSource.Controls.Add(this.txtSourceFolder);
            this.gbSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSource.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSource.Location = new System.Drawing.Point(30, 30);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(914, 90);
            this.gbSource.TabIndex = 0;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source Folder (Required)";
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSource.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSource.Location = new System.Drawing.Point(784, 35);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(120, 23);
            this.btnBrowseSource.TabIndex = 1;
            this.btnBrowseSource.Text = "Browse...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceFolder.Location = new System.Drawing.Point(20, 35);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.ReadOnly = true;
            this.txtSourceFolder.Size = new System.Drawing.Size(758, 27);
            this.txtSourceFolder.TabIndex = 0;
            // 
            // panelProgress
            // 
            this.panelProgress.BackColor = System.Drawing.Color.White;
            this.panelProgress.Controls.Add(this.lblErrorLog);
            this.panelProgress.Controls.Add(this.lnkShowLog);
            this.panelProgress.Controls.Add(this.lblStatus);
            this.panelProgress.Controls.Add(this.progressBar);
            this.panelProgress.Controls.Add(this.lblProgress);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgress.Location = new System.Drawing.Point(3, 411);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelProgress.Size = new System.Drawing.Size(974, 94);
            this.panelProgress.TabIndex = 2;
            // 
            // lblErrorLog
            // 
            this.lblErrorLog.AutoSize = true;
            this.lblErrorLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorLog.Location = new System.Drawing.Point(27, 70);
            this.lblErrorLog.Name = "lblErrorLog";
            this.lblErrorLog.Size = new System.Drawing.Size(73, 20);
            this.lblErrorLog.TabIndex = 4;
            this.lblErrorLog.Text = "Error Log:";
            // 
            // lnkShowLog
            // 
            this.lnkShowLog.AutoSize = true;
            this.lnkShowLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowLog.Location = new System.Drawing.Point(89, 70);
            this.lnkShowLog.Name = "lnkShowLog";
            this.lnkShowLog.Size = new System.Drawing.Size(74, 20);
            this.lnkShowLog.TabIndex = 3;
            this.lnkShowLog.TabStop = true;
            this.lnkShowLog.Text = "Show Log";
            this.lnkShowLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLog_LinkClicked);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(27, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Ready";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(90, 20);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(854, 20);
            this.progressBar.TabIndex = 1;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(27, 23);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(68, 20);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Progress:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(713, 565);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 40);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(849, 565);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.panelHeader, 0, 0);
            this.tableLayoutMain.Controls.Add(this.panelMain, 0, 1);
            this.tableLayoutMain.Controls.Add(this.panelProgress, 0, 2);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 4;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMain.Size = new System.Drawing.Size(980, 610);
            this.tableLayoutMain.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 610);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tableLayoutMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Management Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.gbConfiguration.ResumeLayout(false);
            this.gbConfiguration.PerformLayout();
            this.panelConfigButtons.ResumeLayout(false);
            this.gbDestination.ResumeLayout(false);
            this.gbDestination.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.tableLayoutMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}