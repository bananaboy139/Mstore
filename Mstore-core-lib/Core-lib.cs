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
        public const string StartFolder = "C:/Users/matte/AppData/Roaming/Microsoft/Windows/Start Menu/Programs/Mstore/";

        public static string appdata = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData);

        public static string MstorePath = Path.Combine(appdata, "Mstore/");
        public static string LogFile = Corelib.MstorePath + "Log.txt";

        public static List<Pakage> Pakages = new List<Pakage>();

        public static Pakage Current;

        public static Pakage Downloading;

        public static string AppsFolder = MstorePath + "Apps/";
        public static string PakagesFolder = MstorePath + "Pakages/";
        public static string DownloadsFolder = MstorePath + "Downloads";

        //Functions
        public static void FolderSetup()
        {
            if (!Directory.Exists(MstorePath))
            {
                Directory.CreateDirectory(MstorePath);
            }

            if (!Directory.Exists(AppsFolder))
            {
                Directory.CreateDirectory(AppsFolder);
            }

            if (!Directory.Exists(PakagesFolder))
            {
                Directory.CreateDirectory(PakagesFolder);
            }

            if (!Directory.Exists(StartFolder))
            {
                Directory.CreateDirectory(StartFolder);
            }

            if (!File.Exists(LogFile))
            {
                File.Create(LogFile);
            }

            if (!Directory.Exists(DownloadsFolder))
            {
                Directory.CreateDirectory(DownloadsFolder);
            }
        }

        public static void Import()
        {
            //read pakage files
            foreach (string f in Directory.GetFiles(MstorePath + "Pakages/", "*.json", SearchOption.AllDirectories))
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

        public static void Write(string t)
        {
            DateTime dateToDisplay = new DateTime();
            string text = dateToDisplay.ToString() + ":   " + t + "\n";
            File.AppendAllText(LogFile, text);
        }

        public static void ClearDownloadsFolder()
        {
            foreach (string f in Directory.GetFiles(DownloadsFolder))
            {
                Write(f);
                File.Delete(f);
            }
        }
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

        public void Install(string dow)
        {
            Corelib.Write("Install Starting: " + JName);
            ZipFile.ExtractToDirectory(dow, Path + "Apps/" + JName + "/");
            Corelib.Write("Extract Complete\n " + Name + "\nLocation:  " + Path + JName);
            IsInstalled = true;
            File.Delete(Path + JName + ".zip");
            CreateShortcut();
            Corelib.Write("created shortcut" + JName);
        }

        private void CreateShortcut()
        {
            using (StreamWriter writer = new StreamWriter(Corelib.StartFolder + Name + ".url"))
            {
                string app = Path + "Apps/" + JName + "/" + exe;;
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                writer.WriteLine("IconFile=" + app);
            }
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
                    Corelib.Write(Name + " can not start" + ex);
                }
            }
        }
    }
}