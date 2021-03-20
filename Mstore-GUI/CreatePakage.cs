using Mstore_Core_lib;
using Pakagesn;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mstore_GUI
{
    public partial class CreatePakage : Form
    {
        public CreatePakage()
        {
            InitializeComponent();
        }

        private void CreatePakage_Load(object sender, EventArgs e)
        {
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            Pakage p = new Pakage();

            p.Name = textBoxName.Text;

            p.Description = textBoxDescription.Text;
            p.Description = p.Description.Replace("{n}", Environment.NewLine);

            p.DownloadURL = textBoxURL.Text;

            p.exe = textBoxExe.Text;

            p.JName = textBoxJName.Text;

            p.args = textBoxArgs.Text;

            p.Password = textBoxPassword.Text;

            p.User = textBoxUser.Text;

            Program.Pakages.Add(p);
            Corelib lib = new Corelib();
            lib.ExportList(Program.Pakages);
            Program.Import();
            Close();
        }
    }
}