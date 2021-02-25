﻿using System.IO;
using System.Collections.Generic;
using Mstore_Log_lib;
using Pakages;
using Newtonsoft.Json;

namespace Mstore_Core_lib
{
    public class Corelib
    {
        public string path = Var.Path;

        public List<Pakage> Import(string Path)
        {
            List<Pakage> pakages = new List<Pakage>();

            foreach (string f in Directory.GetFiles(Path + "Pakages/", "*.json", SearchOption.AllDirectories))
            {
                using (StreamReader file = File.OpenText(@f))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                    file.Close();
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
