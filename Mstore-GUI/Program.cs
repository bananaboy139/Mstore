using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mstore_Core_lib;
using Pakagesn;


namespace Mstore_GUI
{
    static class Program
    {
        static Corelib Lib = new Corelib();
        public static List<Pakage> Pakages = new List<Pakage>();
        public static Pakage current;
        public static Pakage Downloading;

        [STAThread]
        static void Main()
        {
            Lib.Write("hello");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window screen = new window();
            Import();
            button.UpdateBtn(screen);
            Application.Run(screen);

        }

        public static void UpdateIsInstalled()
        {
            window w = (window.ActiveForm as window);
            if (current.IsInstalled)
            {
                w.IsInstalled.ForeColor = System.Drawing.Color.Chartreuse;
                w.IsInstalled.Text = Program.current.Name + "\nInstalled";
            }
            else
            {
                w.IsInstalled.ForeColor = System.Drawing.Color.Red;
                w.IsInstalled.Text = Program.current.Name + "\nNOT Installed"; ;
            }
        }
        public static void Import() 
        {
            Pakages = Lib.Import(Lib.path);
            button.UpdateBtn(screen);
        } 
        public static void Export() => Lib.ExportList(Pakages);
    }
}
