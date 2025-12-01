// MainForm.Designer.cs
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
        private System.Windows.Forms.TextBox txtConfigFile;
        private System.Windows.Forms.Button btnBrowseConfig;
        private System.Windows.Forms.Label lblConfigHint;
        private System.Windows.Forms.Panel panelProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel lnkShowLog;
        private System.Windows.Forms.Label lblErrorLog;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.lblDestinationHint = new System.Windows.Forms.Label();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.gbConfiguration = new System.Windows.Forms.GroupBox();
            this.lblConfigHint = new System.Windows.Forms.Label();
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.btnBrowseConfig = new System.Windows.Forms.Button();
            this.chkUseDefaultConfig = new System.Windows.Forms.CheckBox();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.lblErrorLog = new System.Windows.Forms.Label();
            this.lnkShowLog = new System.Windows.Forms.LinkLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.gbDestination.SuspendLayout();
            this.gbConfiguration.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblDescription);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(684, 100);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(254, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "File Management Tool";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblDescription.Location = new System.Drawing.Point(23, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(639, 17);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Organize files in a folder based on their extensions. Files are categorized acco" +
    "rding to configuration rules.";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.gbConfiguration);
            this.panelMain.Controls.Add(this.gbDestination);
            this.panelMain.Controls.Add(this.gbSource);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 100);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(684, 340);
            this.panelMain.TabIndex = 1;
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.btnBrowseSource);
            this.gbSource.Controls.Add(this.txtSourceFolder);
            this.gbSource.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSource.Location = new System.Drawing.Point(23, 23);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(638, 80);
            this.gbSource.TabIndex = 0;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source Folder (Required)";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceFolder.Location = new System.Drawing.Point(20, 35);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.ReadOnly = true;
            this.txtSourceFolder.Size = new System.Drawing.Size(470, 23);
            this.txtSourceFolder.TabIndex = 0;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSource.Location = new System.Drawing.Point(496, 35);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(120, 23);
            this.btnBrowseSource.TabIndex = 1;
            this.btnBrowseSource.Text = "Browse...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // gbDestination
            // 
            this.gbDestination.Controls.Add(this.lblDestinationHint);
            this.gbDestination.Controls.Add(this.btnBrowseDestination);
            this.gbDestination.Controls.Add(this.txtDestinationFolder);
            this.gbDestination.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDestination.Location = new System.Drawing.Point(23, 119);
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.Size = new System.Drawing.Size(638, 120);
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
            this.lblDestinationHint.Size = new System.Drawing.Size(399, 13);
            this.lblDestinationHint.TabIndex = 2;
            this.lblDestinationHint.Text = "If not specified, a timestamped folder will be created automatically";
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinationFolder.Location = new System.Drawing.Point(20, 35);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.ReadOnly = true;
            this.txtDestinationFolder.Size = new System.Drawing.Size(470, 23);
            this.txtDestinationFolder.TabIndex = 0;
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDestination.Location = new System.Drawing.Point(496, 35);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(120, 23);
            this.btnBrowseDestination.TabIndex = 1;
            this.btnBrowseDestination.Text = "Browse...";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // gbConfiguration
            // 
            this.gbConfiguration.Controls.Add(this.lblConfigHint);
            this.gbConfiguration.Controls.Add(this.btnBrowseConfig);
            this.gbConfiguration.Controls.Add(this.txtConfigFile);
            this.gbConfiguration.Controls.Add(this.chkUseDefaultConfig);
            this.gbConfiguration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConfiguration.Location = new System.Drawing.Point(23, 255);
            this.gbConfiguration.Name = "gbConfiguration";
            this.gbConfiguration.Size = new System.Drawing.Size(638, 120);
            this.gbConfiguration.TabIndex = 2;
            this.gbConfiguration.TabStop = false;
            this.gbConfiguration.Text = "Configuration";
            // 
            // lblConfigHint
            // 
            this.lblConfigHint.AutoSize = true;
            this.lblConfigHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigHint.ForeColor = System.Drawing.Color.Gray;
            this.lblConfigHint.Location = new System.Drawing.Point(20, 95);
            this.lblConfigHint.Name = "lblConfigHint";
            this.lblConfigHint.Size = new System.Drawing.Size(425, 13);
            this.lblConfigHint.TabIndex = 3;
            this.lblConfigHint.Text = "JSON file containing category definitions. Uses default configuration if not spec" +
    "ified.";
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigFile.Location = new System.Drawing.Point(20, 60);
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.ReadOnly = true;
            this.txtConfigFile.Size = new System.Drawing.Size(470, 23);
            this.txtConfigFile.TabIndex = 2;
            // 
            // btnBrowseConfig
            // 
            this.btnBrowseConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseConfig.Location = new System.Drawing.Point(496, 60);
            this.btnBrowseConfig.Name = "btnBrowseConfig";
            this.btnBrowseConfig.Size = new System.Drawing.Size(120, 23);
            this.btnBrowseConfig.TabIndex = 3;
            this.btnBrowseConfig.Text = "Browse...";
            this.btnBrowseConfig.UseVisualStyleBackColor = true;
            this.btnBrowseConfig.Click += new System.EventHandler(this.btnBrowseConfig_Click);
            // 
            // chkUseDefaultConfig
            // 
            this.chkUseDefaultConfig.AutoSize = true;
            this.chkUseDefaultConfig.Checked = true;
            this.chkUseDefaultConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultConfig.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseDefaultConfig.Location = new System.Drawing.Point(20, 30);
            this.chkUseDefaultConfig.Name = "chkUseDefaultConfig";
            this.chkUseDefaultConfig.Size = new System.Drawing.Size(176, 19);
            this.chkUseDefaultConfig.TabIndex = 1;
            this.chkUseDefaultConfig.Text = "Use default configuration file";
            this.chkUseDefaultConfig.UseVisualStyleBackColor = true;
            this.chkUseDefaultConfig.CheckedChanged += new System.EventHandler(this.chkUseDefaultConfig_CheckedChanged);
            // 
            // panelProgress
            // 
            this.panelProgress.BackColor = System.Drawing.Color.White;
            this.panelProgress.Controls.Add(this.lblErrorLog);
            this.panelProgress.Controls.Add(this.lnkShowLog);
            this.panelProgress.Controls.Add(this.lblStatus);
            this.panelProgress.Controls.Add(this.progressBar);
            this.panelProgress.Controls.Add(this.lblProgress);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProgress.Location = new System.Drawing.Point(0, 440);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Padding = new System.Windows.Forms.Padding(20);
            this.panelProgress.Size = new System.Drawing.Size(684, 100);
            this.panelProgress.TabIndex = 2;
            // 
            // lblErrorLog
            // 
            this.lblErrorLog.AutoSize = true;
            this.lblErrorLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorLog.Location = new System.Drawing.Point(17, 70);
            this.lblErrorLog.Name = "lblErrorLog";
            this.lblErrorLog.Size = new System.Drawing.Size(56, 15);
            this.lblErrorLog.TabIndex = 4;
            this.lblErrorLog.Text = "Error Log:";
            // 
            // lnkShowLog
            // 
            this.lnkShowLog.AutoSize = true;
            this.lnkShowLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowLog.Location = new System.Drawing.Point(79, 70);
            this.lnkShowLog.Name = "lnkShowLog";
            this.lnkShowLog.Size = new System.Drawing.Size(60, 15);
            this.lnkShowLog.TabIndex = 3;
            this.lnkShowLog.TabStop = true;
            this.lnkShowLog.Text = "Show Log";
            this.lnkShowLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLog_LinkClicked);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(17, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Ready";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(80, 20);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(581, 20);
            this.progressBar.TabIndex = 1;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(17, 23);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(56, 15);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Progress:";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(400, 560);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 40);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(540, 560);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 611);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Management Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.gbDestination.ResumeLayout(false);
            this.gbDestination.PerformLayout();
            this.gbConfiguration.ResumeLayout(false);
            this.gbConfiguration.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}