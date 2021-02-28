using System.IO;
using System.Collections.Generic;
using Mstore_Log_lib;
using Pakagesn;
using Newtonsoft.Json;
using Mstore_Var;

namespace Mstore_Core_lib
{
    public class Corelib
    {
        public string path = Var.Path;

        public List<Pakage> Import(string PATH)
        {
            if (!Directory.Exists(PATH + "Pakages/"))
            {
                Directory.CreateDirectory(PATH + "Pakages/");
            }
            if (!Directory.Exists(PATH + "Apps/"))
            {
                Directory.CreateDirectory(PATH + "Apps/");
            }

            List<Pakage> pakages = new List<Pakage>();

            foreach (string f in Directory.GetFiles(PATH + "Pakages/", "*.json", SearchOption.AllDirectories))
            {
                using StreamReader file = File.OpenText(@f);
                JsonSerializer serializer = new JsonSerializer();
                pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                file.Close();
            }
            
            foreach (Pakage p in pakages)
            {
                if (p.IsInstalled && !Directory.Exists(PATH + "Apps/" + p.JName + "/"))
                {
                    p.IsInstalled = false;
                }
            }

            return pakages;
        }

        public void ExportList(List<Pakage> Pakages)
        {
            foreach (Pakage pakage in Pakages)
            {
                string pakageinfo = JsonConvert.SerializeObject(pakage);
                string FileName = path + "Pakages/" + pakage.JName + ".json";
                
                File.WriteAllText(@FileName, pakageinfo);
            }
        }
        public void Write(string text) => Logger.Write(text);

    }
}
