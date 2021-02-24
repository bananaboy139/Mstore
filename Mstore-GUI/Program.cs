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
        static List<Pakage> Pakages = new List<Pakage>();

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new window());

            Import();

        }

        static void ShowPackages()
        {
            foreach (Pakage P in Pakages)
            {
                //TODO: clone textbox1 with text = P.Name
            }
        }



        static void Import() => Pakages = Lib.Import(Lib.path);

        static void Export() => Lib.ExportList(Pakages);

    }
}
