
namespace Mstore_GUI
{
    partial class CreatePakage
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.LabelDownloadURL = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelJName = new System.Windows.Forms.Label();
            this.textBoxJName = new System.Windows.Forms.TextBox();
            this.labelExe = new System.Windows.Forms.Label();
            this.textBoxExe = new System.Windows.Forms.TextBox();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.labelArgs = new System.Windows.Forms.Label();
            this.textBoxArgs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(114, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(270, 23);
            this.textBoxName.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(42, 15);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name:";
            // 
            // LabelDownloadURL
            // 
            this.LabelDownloadURL.AutoSize = true;
            this.LabelDownloadURL.Location = new System.Drawing.Point(12, 47);
            this.LabelDownloadURL.Name = "LabelDownloadURL";
            this.LabelDownloadURL.Size = new System.Drawing.Size(85, 15);
            this.LabelDownloadURL.TabIndex = 3;
            this.LabelDownloadURL.Text = "DownloadURL:";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(114, 44);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(270, 23);
            this.textBoxURL.TabIndex = 2;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(13, 89);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(70, 15);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(114, 86);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(270, 23);
            this.textBoxDescription.TabIndex = 4;
            // 
            // labelJName
            // 
            this.labelJName.AutoSize = true;
            this.labelJName.Location = new System.Drawing.Point(13, 131);
            this.labelJName.Name = "labelJName";
            this.labelJName.Size = new System.Drawing.Size(46, 15);
            this.labelJName.TabIndex = 7;
            this.labelJName.Text = "JName:";
            // 
            // textBoxJName
            // 
            this.textBoxJName.Location = new System.Drawing.Point(114, 128);
            this.textBoxJName.Name = "textBoxJName";
            this.textBoxJName.Size = new System.Drawing.Size(270, 23);
            this.textBoxJName.TabIndex = 6;
            // 
            // labelExe
            // 
            this.labelExe.AutoSize = true;
            this.labelExe.Location = new System.Drawing.Point(13, 172);
            this.labelExe.Name = "labelExe";
            this.labelExe.Size = new System.Drawing.Size(28, 15);
            this.labelExe.TabIndex = 9;
            this.labelExe.Text = "exe:";
            // 
            // textBoxExe
            // 
            this.textBoxExe.Location = new System.Drawing.Point(114, 169);
            this.textBoxExe.Name = "textBoxExe";
            this.textBoxExe.Size = new System.Drawing.Size(270, 23);
            this.textBoxExe.TabIndex = 8;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(176, 270);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(81, 27);
            this.ExportBtn.TabIndex = 10;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // labelArgs
            // 
            this.labelArgs.AutoSize = true;
            this.labelArgs.Location = new System.Drawing.Point(12, 206);
            this.labelArgs.Name = "labelArgs";
            this.labelArgs.Size = new System.Drawing.Size(34, 15);
            this.labelArgs.TabIndex = 12;
            this.labelArgs.Text = "Args:";
            // 
            // textBoxArgs
            // 
            this.textBoxArgs.Location = new System.Drawing.Point(114, 203);
            this.textBoxArgs.Name = "textBoxArgs";
            this.textBoxArgs.Size = new System.Drawing.Size(270, 23);
            this.textBoxArgs.TabIndex = 11;
            // 
            // CreatePakage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 328);
            this.Controls.Add(this.labelArgs);
            this.Controls.Add(this.textBoxArgs);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.labelExe);
            this.Controls.Add(this.textBoxExe);
            this.Controls.Add(this.labelJName);
            this.Controls.Add(this.textBoxJName);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.LabelDownloadURL);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Name = "CreatePakage";
            this.Text = "Create Pakage";
            this.Load += new System.EventHandler(this.CreatePakage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label LabelDownloadURL;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelJName;
        private System.Windows.Forms.TextBox textBoxJName;
        private System.Windows.Forms.Label labelExe;
        private System.Windows.Forms.TextBox textBoxExe;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Label labelArgs;
        private System.Windows.Forms.TextBox textBoxArgs;
    }
}