using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;

namespace Mstore_Core_lib
{
    public static class Corelib
    {
        public static string appdata = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData);
        public static string MstorePath = Path.Combine(appdata, "Mstore/");

        public static List<Pakage> Import()
        {

            if (!Directory.Exists(MstorePath + "Pakages/"))
            {
                Directory.CreateDirectory(MstorePath + "Pakages/");
            }
            if (!Directory.Exists(MstorePath + "Apps/"))
            {
                Directory.CreateDirectory(MstorePath + "Apps/");
            }

            List<Pakage> pakages = new List<Pakage>();

            foreach (string f in Directory.GetFiles(MstorePath + "Pakages/", "*.json", SearchOption.AllDirectories))
            {
                using StreamReader file = File.OpenText(@f);
                JsonSerializer serializer = new JsonSerializer();
                pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                file.Close();
            }

            foreach (Pakage p in pakages)
            {
                if (p.IsInstalled && !Directory.Exists(MstorePath + "Apps/" + p.JName + "/"))
                {
                    p.IsInstalled = false;
                }
            }

            return pakages;
        }

        public static void ExportList(List<Pakage> Pakages)
        {
            File.WriteAllText(appdata, MstorePath);
            foreach (Pakage pakage in Pakages)
            {
                string pakageinfo = JsonConvert.SerializeObject(pakage);
                string FileName = MstorePath + "Pakages/" + pakage.JName + ".json";

                File.WriteAllText(@FileName, pakageinfo);
            }
        }

        public static void  Write(string text) => Logger.Write(text);
    }

    public class Pakage
    {
        public string Name;
        public string DownloadURL;
        public string Description;
        public string JName;
        public string exe;
        public string args;
        private string Path = Corelib.MstorePath; //FIXME: remove this line
        public bool IsInstalled = false;
        public string User;
        public string Password;
        public void Install()
        {
            Logger.Write("Download finished: " + JName);
            ZipFile.ExtractToDirectory(Path + JName + ".zip", Path + "Apps/" + JName + "/");
            Logger.Write("Extract Complete\n " + Name + "\nLocation:  " + Path + JName);
            IsInstalled = true;
            File.Delete(Path + JName + ".zip");
        }

        public void Run()
        {
            if (IsInstalled)
            {
                var currentdir = Directory.GetCurrentDirectory();
                try
                {
                    Directory.SetCurrentDirectory(new FileInfo(Path + "Apps/" + JName + "/" + exe).Directory.FullName);
                    Process Launcher = new Process();
                    Launcher.StartInfo.FileName = Path + "Apps/" + JName + "/" + exe;
                    Launcher.StartInfo.Arguments = args;
                    Launcher.Start();
                    Directory.SetCurrentDirectory(currentdir);
                }
                catch (Win32Exception ex)
                {
                    Logger.Write(Name + " can not start" + ex);
                }
            }
        }
    }

    public class Logger
    {
        public static string LogFile = Corelib.MstorePath + "Log.txt";

        public static void Write(string t)
        {
            DateTime dateToDisplay = new DateTime();
            string text = dateToDisplay.ToString() + ":   " + t + "\n";
            File.AppendAllText(LogFile, text);
        }
    }
}