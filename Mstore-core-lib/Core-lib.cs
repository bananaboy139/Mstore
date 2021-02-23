using Newtonsoft.Json;
using Pakages;
using System.IO;
using System.Collections.Generic;
using Mstore_Log_lib;


namespace Mstore_Core_lib
{
    public class Corelib
    {
        public string path = @"./Mstore/";

        public void start ()
        {
            Directory.CreateDirectory(path);
            
        }

        public dynamic ImportList(string sDir)
        {
            List<Pakage> pakages = new List<Pakage>();
            foreach (string f in Directory.GetFiles(sDir))
            {
                if (Path.GetExtension(f) == ".json")
                {
                    using (StreamReader file = File.OpenText(@f))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                    }
                    return pakages;
                }
            }

            foreach (string d in Directory.GetDirectories(sDir))
            {
                ImportList(d);
            }
            write("Did not find any json files");
            return null;
        }

        public void ExportList(List<Pakage> Pakages)
        {
            foreach (Pakage pakage in Pakages)
            {
                string pakageinfo = JsonConvert.SerializeObject(pakage);
                string FileName = path + pakage.JName + ".json";
                
                File.WriteAllText(@FileName, pakageinfo);
            }
            
        }

        public async void write (string text)
        {
            await Logger.Write(text);
        }


        public void Export(Pakage Pakage)
        {
            string pakageinfo = JsonConvert.SerializeObject(Pakage);
            string FileName = path + Pakage.JName + ".json";

            File.WriteAllText(@FileName, pakageinfo);
        }


        void spelunky()
        {
            Pakage Spelunky_Classic = new Pakage
            {
                Name = "Spelunky Classic",
                DownloadURL = "http://www.derekyu.com/games/spelunky_1_1.zip",
                Description = "Spelunky is a cave exploration / treasure-hunting game inspired by classic platform games and roguelikes," +
                " where the goal is to grab as much treasure from the cave as possible. Every time you play the cave's layout will be different. " +
                "Use your wits, your reflexes, and the items available to you to survive and go ever deeper! " +
                "Perhaps at the end you may find what you're looking for...",
                Folder = "Spelunky/",
                EXEPath = "Spelunky.EXE",
                JName = "Spelunky_classic"
            };
        }
        void xonotic() 
        {
            Pakage Xonotic = new Pakage
            {
                Name = "Xonotic",
                DownloadURL = "https://dl.xonotic.org/xonotic-0.8.2.zip",
                Description = "Xonotic is an addictive, arena-style first person shooter with crisp movement and a wide array of weapons. " +
                "It combines intuitive mechanics with in-your-face action to elevate your heart rate." +
                "Xonotic is and will always be free-to-play. It is available under the copyleft-style GPLv3+ license.",
                Folder = "Xonotic/",
                EXEPath = "xonotic.exe",
                JName = "Xonotic"
            };
        }

    }
}
