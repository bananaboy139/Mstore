using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mstore_Var;
using Mstore_Core_lib;

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
                    Var.path = Path.GetFullPath(NewPath.SelectedPath + "/");
                    ShowPathLabel.Text = Var.path;
                    Corelib lib = new Corelib();
                    MessageBox.Show("found: " + lib.path, "Message");
                    Program.Export();
                }
            }
        }
    }
}
