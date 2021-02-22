using System;
using Newtonsoft.Json;
using Pakages;
using System.IO;


namespace Mstore_Core_lib
{
    class Corelib
    {
        private string path;
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
            Spelunky_Classic.URL = "http://www.derekyu.com/games/spelunky_1_1.zip";
            Spelunky_Classic.Description = "Spelunky is a cave exploration / treasure-hunting game inspired by classic platform games and roguelikes," +
                " where the goal is to grab as much treasure from the cave as possible. Every time you play the cave's layout will be different. " +
                "Use your wits, your reflexes, and the items available to you to survive and go ever deeper! " +
                "Perhaps at the end you may find what you're looking for...";
            Spelunky_Classic.EXEPath = "";
        }
    }
}
