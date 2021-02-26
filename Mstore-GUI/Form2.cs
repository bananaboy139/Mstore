using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pakages;
using Mstore_Core_lib;


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
            p.DownloadURL = textBoxURL.Text;
            p.exe = textBoxExe.Text;
            p.JName = textBoxJName.Text;
            p.args = textBoxArgs.Text;
            Program.Pakages.Add(p);
            Corelib lib = new Corelib();
            lib.ExportList(Program.Pakages);
            Close();
        }
    }
}
