
namespace Mstore_GUI
{
    partial class MoreInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.MoreInfoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MoreInfoLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 158);
            this.panel1.TabIndex = 0;
            // 
            // MoreInfoLabel
            // 
            this.MoreInfoLabel.AutoSize = true;
            this.MoreInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MoreInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.MoreInfoLabel.Name = "MoreInfoLabel";
            this.MoreInfoLabel.Size = new System.Drawing.Size(247, 75);
            this.MoreInfoLabel.TabIndex = 0;
            this.MoreInfoLabel.Text = "press the \'Open REPO folder\' button.\r\ndrag and drop your Json files in there.\r\nPr" +
    "ess the \'Import\' button.\r\n\r\nBefore closing this app, ALWAYS press export.";
            // 
            // MoreInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 158);
            this.Controls.Add(this.panel1);
            this.Name = "MoreInfo";
            this.Text = "More Info";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MoreInfoLabel;
    }
}