using System;
using System.Windows.Forms;
using Pakagesn;


namespace Mstore_GUI
{
    class button
    {
        public static void UpdateBtn()
        {
            window w = (Program.windows[0] as window);
            w.MainPanel.Controls.Clear();
            foreach (Pakage p in Program.Pakages)
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
                w.MainPanel.Controls.Add(text);
            }
        }

        static void Click(object sender, EventArgs s)
        {
            String name;
            if (sender is Button)
            {
                name = (sender as Button).Name;
                foreach (Pakage p in Program.Pakages)
                {
                    if (name == p.JName)
                    {
                        Program.current = p;
                    }
                }
                window w = (Program.windows[0] as window);
                w.DescriptionLabel.Text = "Description: \n" + Program.current.Description;
                w.PakageNameLabel.Text = "Name: \n" + Program.current.Name;
                Program.UpdateIsInstalled();
            }
        }

    }
}
