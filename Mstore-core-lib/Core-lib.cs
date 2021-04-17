﻿using Mstore_Log_lib;
using Mstore_Var;
using Newtonsoft.Json;
using Pakagesn;
using System.Collections.Generic;
using System.IO;

namespace Mstore_Core_lib
{
    public class Corelib
    {
        public string path = Var.MstorePath;
        public string appdata = Var.appdata;

        public List<Pakage> Import()
        {

            if (!Directory.Exists(path + "Pakages/"))
            {
                Directory.CreateDirectory(path + "Pakages/");
            }
            if (!Directory.Exists(path + "Apps/"))
            {
                Directory.CreateDirectory(path + "Apps/");
            }

            List<Pakage> pakages = new List<Pakage>();

            foreach (string f in Directory.GetFiles(path + "Pakages/", "*.json", SearchOption.AllDirectories))
            {
                using StreamReader file = File.OpenText(@f);
                JsonSerializer serializer = new JsonSerializer();
                pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                file.Close();
            }

            foreach (Pakage p in pakages)
            {
                if (p.IsInstalled && !Directory.Exists(path + "Apps/" + p.JName + "/"))
                {
                    p.IsInstalled = false;
                }
            }

            return pakages;
        }

        public void ExportList(List<Pakage> Pakages)
        {
            File.WriteAllText(appdata, Var.path);
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