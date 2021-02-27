using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pakagesn;
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
            //TODO: stop \n --> \\n in textbox
            Pakage p = new Pakage();
            List<TextBox> textboxes = new List<TextBox>()
            {
                textBoxName,
                textBoxDescription,
                textBoxURL,
                textBoxExe,
                textBoxJName,
                textBoxArgs
            };
            foreach (TextBox t in textboxes)
            {
                if (t.Text == "")
                {
                    t.Text = null;
                }
            }
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
