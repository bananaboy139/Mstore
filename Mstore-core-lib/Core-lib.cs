using System.IO;
using System.Collections.Generic;
using Mstore_Log_lib;
using Pakages;
using Newtonsoft.Json;


namespace Mstore_Core_lib
{
    public class Corelib
    {
        public string path = @"./Mstore/";

        public void Start() => Directory.CreateDirectory(path);

        public List<Pakage> Import(string Path)
        {
            List<Pakage> pakages = new List<Pakage>();

            foreach (string f in Directory.GetFiles(Path, "*.json", SearchOption.AllDirectories))
            {
                using (StreamReader file = File.OpenText(@f))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                }
            }
            return pakages;
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

        public async void write(string text) => await Logger.Write(text);

        public void Export(Pakage Pakage)
        {
            string pakageinfo = JsonConvert.SerializeObject(Pakage);
            string FileName = path + Pakage.JName + ".json";

            File.WriteAllText(@FileName, pakageinfo);
        }
    }
}
