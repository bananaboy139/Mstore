using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace Mstore_Core_lib
{
    public static class Corelib
    {
        public static string StartFolder = "C:/Users/matte/AppData/Roaming/Microsoft/Windows/Start Menu/Programs/Mstore";

        public static string appdata = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData);

        public static string MstorePath = Path.Combine(appdata, "Mstore/");

        public static List<Pakage> Pakages = new List<Pakage>();

        public static Pakage Current;

        public static Pakage Downloading;

        //Functions
        public static void FolderSetup()
        {
            if (!Directory.Exists(MstorePath))
            {
                Directory.CreateDirectory(MstorePath);
            }
            if (!Directory.Exists(MstorePath + "Apps/"))
            {
                Directory.CreateDirectory(MstorePath + "Apps/");
            }
            if (!Directory.Exists(MstorePath + "Pakages/"))
            {
                Directory.CreateDirectory(MstorePath + "Pakages/");
            }
            if (!Directory.Exists(StartFolder))
            {
                Directory.CreateDirectory(StartFolder);
            }
        }

        public static List<Pakage> Import()
        {
            //read pakage files
            foreach (string f in Directory.GetFiles(MstorePath + "Pakages/", "*.json", SearchOption.TopDirectoryOnly))
            {
                using StreamReader file = File.OpenText(@f);
                JsonSerializer serializer = new JsonSerializer();
                Pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                file.Close();
            }
            //check if installed
            foreach (Pakage p in Pakages)
            {
                if (!Directory.Exists(MstorePath + "Apps/" + p.JName + "/"))
                {
                    p.IsInstalled = false;
                }
                else
                {
                    p.IsInstalled = true;
                }
            }

            return Pakages;
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

        public static void Write(string text) => Logger.Write(text);
    }

    public class Pakage
    {
        public string Name;
        public string DownloadURL;
        public string Description;
        public string JName;
        public string exe;
        public string args;
        private string Path = Corelib.MstorePath;
        public bool IsInstalled = false;
        public string User;
        public string Password;

        public void Install()
        {
            Logger.Write("Install Starting: " + JName);
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