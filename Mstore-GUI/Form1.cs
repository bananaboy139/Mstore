using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mstore_Core_lib;


namespace Mstore_GUI
{
    public partial class window : Form
    {
        public window()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            Corelib lib = new Corelib();
            string path = lib.path + Program.current.Folder + Program.current.EXEPath;


        }

    }
}
