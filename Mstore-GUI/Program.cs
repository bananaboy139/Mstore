using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mstore_Core_lib;
using Pakages;

namespace Mstore_GUI
{
    static class Program
    {
        static Corelib Lib = new Corelib();
        static List<Pakage> Pakages;

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void import()
        {
            Pakages = Lib.ImportList(Lib.path);
        }

        static void export()
        {
            Lib.ExportList(Pakages);
        }

    }
}
