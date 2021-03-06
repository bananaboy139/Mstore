﻿

namespace Mstore_GUI
{
    partial class window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(window));
            this.SideBar = new System.Windows.Forms.Panel();
            this.ChangePathBtn = new System.Windows.Forms.Button();
            this.InfoBtn = new System.Windows.Forms.Button();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.DeleteGameBtn = new System.Windows.Forms.Button();
            this.OpenFolderBtn = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.IsInstalled = new System.Windows.Forms.Label();
            this.DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.RunButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.PakageName = new System.Windows.Forms.Panel();
            this.PakageNameLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.SideBar.SuspendLayout();
            this.PakageName.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(14)))), ((int)(((byte)(33)))));
            this.SideBar.Controls.Add(this.ChangePathBtn);
            this.SideBar.Controls.Add(this.InfoBtn);
            this.SideBar.Controls.Add(this.CreateBtn);
            this.SideBar.Controls.Add(this.DeleteGameBtn);
            this.SideBar.Controls.Add(this.OpenFolderBtn);
            this.SideBar.Controls.Add(this.ImportButton);
            this.SideBar.Controls.Add(this.ExportButton);
            this.SideBar.Controls.Add(this.IsInstalled);
            this.SideBar.Controls.Add(this.DownloadProgress);
            this.SideBar.Controls.Add(this.RunButton);
            this.SideBar.Controls.Add(this.DownloadButton);
            this.SideBar.Controls.Add(this.PakageName);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(200, 636);
            this.SideBar.TabIndex = 0;
            // 
            // ChangePathBtn
            // 
            this.ChangePathBtn.BackColor = System.Drawing.Color.Gray;
            this.ChangePathBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChangePathBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.ChangePathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangePathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ChangePathBtn.Location = new System.Drawing.Point(0, 440);
            this.ChangePathBtn.Name = "ChangePathBtn";
            this.ChangePathBtn.Size = new System.Drawing.Size(200, 34);
            this.ChangePathBtn.TabIndex = 10;
            this.ChangePathBtn.Text = "Change Folder Location";
            this.ChangePathBtn.UseVisualStyleBackColor = false;
            this.ChangePathBtn.Click += new System.EventHandler(this.ChangePathBtn_Click);
            // 
            // InfoBtn
            // 
            this.InfoBtn.BackColor = System.Drawing.Color.Gray;
            this.InfoBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.InfoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoBtn.Location = new System.Drawing.Point(0, 406);
            this.InfoBtn.Name = "InfoBtn";
            this.InfoBtn.Size = new System.Drawing.Size(200, 34);
            this.InfoBtn.TabIndex = 9;
            this.InfoBtn.Text = "More Info";
            this.InfoBtn.UseVisualStyleBackColor = false;
            this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
            // 
            // CreateBtn
            // 
            this.CreateBtn.BackColor = System.Drawing.Color.Gray;
            this.CreateBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.CreateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreateBtn.Location = new System.Drawing.Point(0, 372);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(200, 34);
            this.CreateBtn.TabIndex = 8;
            this.CreateBtn.Text = "Create Pakage";
            this.CreateBtn.UseVisualStyleBackColor = false;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // DeleteGameBtn
            // 
            this.DeleteGameBtn.BackColor = System.Drawing.Color.Gray;
            this.DeleteGameBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteGameBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.DeleteGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteGameBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DeleteGameBtn.Location = new System.Drawing.Point(0, 338);
            this.DeleteGameBtn.Name = "DeleteGameBtn";
            this.DeleteGameBtn.Size = new System.Drawing.Size(200, 34);
            this.DeleteGameBtn.TabIndex = 7;
            this.DeleteGameBtn.Text = "Delete";
            this.DeleteGameBtn.UseVisualStyleBackColor = false;
            this.DeleteGameBtn.Click += new System.EventHandler(this.DeleteGameBtn_Click);
            // 
            // OpenFolderBtn
            // 
            this.OpenFolderBtn.BackColor = System.Drawing.Color.Gray;
            this.OpenFolderBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.OpenFolderBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.OpenFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFolderBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.OpenFolderBtn.Location = new System.Drawing.Point(0, 304);
            this.OpenFolderBtn.Name = "OpenFolderBtn";
            this.OpenFolderBtn.Size = new System.Drawing.Size(200, 34);
            this.OpenFolderBtn.TabIndex = 6;
            this.OpenFolderBtn.Text = "Open REPO Folder";
            this.OpenFolderBtn.UseVisualStyleBackColor = false;
            this.OpenFolderBtn.Click += new System.EventHandler(this.OpenFolderBtn_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.BackColor = System.Drawing.Color.Gray;
            this.ImportButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ImportButton.Location = new System.Drawing.Point(0, 270);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(200, 34);
            this.ImportButton.TabIndex = 5;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = false;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.BackColor = System.Drawing.Color.Gray;
            this.ExportButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ExportButton.Location = new System.Drawing.Point(0, 236);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(200, 34);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = false;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // IsInstalled
            // 
            this.IsInstalled.AutoSize = true;
            this.IsInstalled.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsInstalled.ForeColor = System.Drawing.Color.Chartreuse;
            this.IsInstalled.Location = new System.Drawing.Point(0, 191);
            this.IsInstalled.MinimumSize = new System.Drawing.Size(19, 45);
            this.IsInstalled.Name = "IsInstalled";
            this.IsInstalled.Size = new System.Drawing.Size(19, 45);
            this.IsInstalled.TabIndex = 3;
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.DownloadProgress.Location = new System.Drawing.Point(0, 168);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(200, 23);
            this.DownloadProgress.TabIndex = 1;
            // 
            // RunButton
            // 
            this.RunButton.BackColor = System.Drawing.Color.Gray;
            this.RunButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RunButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RunButton.Location = new System.Drawing.Point(0, 134);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(200, 34);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.BackColor = System.Drawing.Color.Gray;
            this.DownloadButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DownloadButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DownloadButton.Location = new System.Drawing.Point(0, 100);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(200, 34);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = false;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // PakageName
            // 
            this.PakageName.Controls.Add(this.PakageNameLabel);
            this.PakageName.Dock = System.Windows.Forms.DockStyle.Top;
            this.PakageName.Location = new System.Drawing.Point(0, 0);
            this.PakageName.Name = "PakageName";
            this.PakageName.Size = new System.Drawing.Size(200, 100);
            this.PakageName.TabIndex = 0;
            // 
            // PakageNameLabel
            // 
            this.PakageNameLabel.AutoSize = true;
            this.PakageNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PakageNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PakageNameLabel.Location = new System.Drawing.Point(0, 0);
            this.PakageNameLabel.Name = "PakageNameLabel";
            this.PakageNameLabel.Size = new System.Drawing.Size(57, 20);
            this.PakageNameLabel.TabIndex = 0;
            this.PakageNameLabel.Text = "Name:";
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(52)))), ((int)(((byte)(94)))));
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPanel.Location = new System.Drawing.Point(200, 269);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1134, 367);
            this.MainPanel.TabIndex = 1;
            // 
            // InfoPanel
            // 
            this.InfoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InfoPanel.Controls.Add(this.ImageBox);
            this.InfoPanel.Controls.Add(this.DescriptionLabel);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoPanel.Location = new System.Drawing.Point(200, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(1134, 269);
            this.InfoPanel.TabIndex = 2;
            // 
            // ImageBox
            // 
            this.ImageBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ImageBox.Location = new System.Drawing.Point(1004, 0);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(130, 269);
            this.ImageBox.TabIndex = 1;
            this.ImageBox.TabStop = false;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DescriptionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.DescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.DescriptionLabel.MaximumSize = new System.Drawing.Size(994, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(99, 20);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Description: ";
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1334, 636);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.SideBar);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "window";
            this.Text = "Mstore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.window_FormClosing);
            this.SideBar.ResumeLayout(false);
            this.SideBar.PerformLayout();
            this.PakageName.ResumeLayout(false);
            this.PakageName.PerformLayout();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SideBar;
        public System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Panel PakageName;
        private System.Windows.Forms.Button RunButton;
        public System.Windows.Forms.Label PakageNameLabel;
        private System.Windows.Forms.Panel InfoPanel;
        public System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.ProgressBar DownloadProgress;
        public System.Windows.Forms.Label IsInstalled;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button OpenFolderBtn;
        private System.Windows.Forms.Button DeleteGameBtn;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Button InfoBtn;
        public System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Button ChangePathBtn;
    }
}

