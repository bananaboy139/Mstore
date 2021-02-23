using System;
using Newtonsoft.Json;
using Pakages;
using System.IO;

namespace Mstore_Core_lib
{
    class Corelib
    {
        private string path = "./Mstore/";
        public void ImportList(string sDir)
        {
            foreach (string f in Directory.GetFiles(sDir))
            {
                if (Path.GetExtension(f) == ".json")
                {
                    JsonConvert.DeserializeObject(f);
                }
            }

            foreach (string d in Directory.GetDirectories(sDir))
            {
                ImportList(d);
            }
        }

        public void ExportList(Pakage[] Pakages)
        {
            foreach (Pakage pakage in Pakages)
            {
                string pakageinfo = JsonConvert.SerializeObject(pakage);
                string FileName = path + pakage.Name + ".json";
                File.WriteAllText(FileName, pakageinfo);
            }
            
        }

        public void spelunky()
        {
            Pakage Spelunky_Classic = new Pakage();
            Spelunky_Classic.Name = "Spelunky Classic";
            Spelunky_Classic.DownloadURL = "http://www.derekyu.com/games/spelunky_1_1.zip";
            Spelunky_Classic.Description = "Spelunky is a cave exploration / treasure-hunting game inspired by classic platform games and roguelikes," +
                " where the goal is to grab as much treasure from the cave as possible. Every time you play the cave's layout will be different. " +
                "Use your wits, your reflexes, and the items available to you to survive and go ever deeper! " +
                "Perhaps at the end you may find what you're looking for...";
            Spelunky_Classic.EXEPath = "Spelunky.EXE";
        }
        public void xonotic() 
        {
            Pakage Xonotic = new Pakage();
            Xonotic.Name = "Xonotic";
            Xonotic.DownloadURL = "https://dl.xonotic.org/xonotic-0.8.2.zip";
            Xonotic.Description = "Xonotic is an addictive, arena-style first person shooter with crisp movement and a wide array of weapons. " +
                "It combines intuitive mechanics with in-your-face action to elevate your heart rate." + 
                "Xonotic is and will always be free-to-play. It is available under the copyleft-style GPLv3+ license.";
            Xonotic.EXEPath = "xonotic.exe";
        }

    }
}
