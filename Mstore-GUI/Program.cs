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
        public static List<Pakage> Pakages = new List<Pakage>();
        public static Pakage current;

        [STAThread]
        static void Main()
        {
            Import();
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window screen = new window();

            foreach (Pakage p in Pakages)
            {

                Button text = new Button()
                {
                    BackColor = System.Drawing.SystemColors.HotTrack,
                    Dock = DockStyle.Top,
                    Location = new System.Drawing.Point(0, 19),
                    Name = p.JName,
                    Text = p.Name,
                    Size = new System.Drawing.Size(200, 34)
                };
                text.Click += new EventHandler(Click);
                screen.MainPanel.Controls.Add(text);
            }
            
            Application.Run(screen);
        }


        static void Click(object sender, EventArgs e)
        {
            String name;
            if (sender is Button)
            {
                name = (sender as Button).Name;
                foreach (Pakage p in Pakages)
                {
                    if (name == p.JName)
                    {
                        current = p;
                    }
                }
            }
                
        }
        static void Import() => Pakages = Lib.Import(Lib.path);
        static void Export() => Lib.ExportList(Pakages);
    }
}
