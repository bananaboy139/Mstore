using Mstore_Core_lib;
using Mstore_Var;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mstore_GUI
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void ChangePathBtn_Click(object sender, EventArgs e)
        {
            using (var NewPath = new FolderBrowserDialog())
            {
                DialogResult result = NewPath.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(NewPath.SelectedPath))
                {
                    Var.MstorePath = Path.GetFullPath(NewPath.SelectedPath + "/");
                    ShowPathLabel.Text = Var.MstorePath;
                    Corelib lib = new Corelib();
                    MessageBox.Show("found: " + lib.path, "Message");
                    Program.Export();
                }
            }
        }
    }
}