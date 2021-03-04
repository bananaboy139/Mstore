using System;
using System.IO;
using System.Drawing;
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
        public static List<Form> windows = new List<Form>();
        [STAThread]
        static void Main()
        {
            Import();
            Lib.Write("hello");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window screen = new window();
            windows.Add(screen);
            
            Application.Run(screen);
        }
        public static void UpdateIsInstalled()
        {
            window w = (windows[0] as window);
            if (current.IsInstalled)
            {
                w.IsInstalled.ForeColor = Color.Chartreuse;
                w.IsInstalled.Text = current.Name + "\nInstalled";
                Bitmap image = Icon.ExtractAssociatedIcon(Lib.path + "Apps/" + current.JName + "/" + current.exe).ToBitmap();
                image = new Bitmap(image, new Size(image.Width * 4, image.Height * 4));
                w.ImageBox.Image = image;
            }
            else
            {
                w.IsInstalled.ForeColor = Color.Red;
                w.IsInstalled.Text = current.Name + "\nNOT Installed";
                Icon icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                Bitmap image = new Bitmap(
                    icon.ToBitmap(), 
                    new Size(icon.ToBitmap().Width * 4, icon.ToBitmap().Height * 4));
                w.ImageBox.Image = image;
            }
        }
        public static void Import() 
        {
            Pakages = Lib.Import();
            button.UpdateBtn();
        } 
        public static void Export() => Lib.ExportList(Pakages);
    }
}
