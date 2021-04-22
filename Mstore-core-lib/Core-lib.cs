using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace Mstore_Core_lib
{
    public static class Corelib
    {
        public static string StartFolder = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
        public static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string MstorePath = Path.Combine(appdata, "Mstore/");
        public static string LogFile = Path.Combine(MstorePath, "Log.txt");
        public static string AppsFolder = Path.Combine(MstorePath, "Apps/");
        public static string PakagesFolder = Path.Combine(MstorePath, "Pakages/");
        public static string DownloadsFolder = Path.Combine(MstorePath, "Downloads/");

        public static List<Pakage> Pakages = new List<Pakage>();

        public static Pakage Current;

        public static Pakage Downloading;

        //Functions

        public static void Setup()
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

            ClearDownloadsFolder();
        }

        public static void Import()
        {
            JsonSerializer serializer = new JsonSerializer();
            //import Config
            try
            {
                using StreamReader Cfile = File.OpenText(Config.ConfigFile);
                Config C = (Config)serializer.Deserialize(Cfile, typeof(Config));
                Cfile.Close();
            }
            catch (FileNotFoundException ex)
            {
                Write(ex.ToString());
                ExportList();
            }

            Pakages.Clear();

            //read pakage files
            if (Config.StoreSecured)
            {
                foreach (string f in Directory.GetFiles(PakagesFolder, "*.json", SearchOption.TopDirectoryOnly))
                {
                    //FIXME: new encryption not working
                    try
                    {
                        File.Decrypt(f);
                    }
                    catch (System.IO.IOException e)
                    {
                        Write(e.ToString());
                    }
                    using StreamReader file = File.OpenText(f);
                    Pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                    file.Close();

                    File.Encrypt(f);
                }
            }
            else
            {
                foreach (string f in Directory.GetFiles(PakagesFolder, "*.json", SearchOption.TopDirectoryOnly))
                {
                    using StreamReader file = File.OpenText(f);
                    Pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                    file.Close();
                }
            }

            //check if installed
            foreach (Pakage p in Pakages)
            {
                if (!Directory.Exists(AppsFolder + p.JName + "/"))
                {
                    p.IsInstalled = false;
                }
                else
                {
                    p.IsInstalled = true;
                }
            }
        }

        public static void ExportList()
        {
            try
            {
                if (Config.StoreSecured)
                {
                    foreach (Pakage pakage in Pakages)
                    {
                        string pakageinfo = JsonConvert.SerializeObject(pakage);
                        string FileName = MstorePath + "Pakages/" + pakage.JName + ".json";

                        File.WriteAllText(FileName, pakageinfo);
                        File.Encrypt(FileName);
                    }
                }
                else
                {
                    foreach (Pakage pakage in Pakages)
                    {
                        string pakageinfo = JsonConvert.SerializeObject(pakage);
                        string FileName = MstorePath + "Pakages/" + pakage.JName + ".json";

                        File.WriteAllText(FileName, pakageinfo);
                    }
                }


                //export config
                Config c = new Config();
                string Configuration = JsonConvert.SerializeObject(c);
                File.WriteAllText(Config.ConfigFile, Configuration);
            }
            catch (Exception e)
            {
                Write(e.ToString());
                throw new Exception(e.ToString());
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
            foreach (string d in Directory.GetDirectories(DownloadsFolder))
            {
                Write(d);
                Directory.Delete(d, true);
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
        public string User;
        public bool IsHashed = false;
        [JsonIgnore]
        public bool IsInstalled = false;

        //fixme: add option to store, for idiots
        //storing passwords in plain text is the single stupidest thing ever, don't ever store passwords in plain text
        public bool ShouldSerializePassword()
        {
            return Config.StorePass;
        }

        public string Password;

        public void Install(string dow)
        {
            Corelib.Write("Install Starting: " + JName);
            ZipFile.ExtractToDirectory(dow, Corelib.AppsFolder + JName + "/");
            Corelib.Write("Extract Complete\n " + Name + "\nLocation:  " + Corelib.MstorePath + JName);
            IsInstalled = true;
            File.Delete(Corelib.MstorePath + JName + ".zip");
            CreateShortcut();
            Corelib.Write("created shortcut" + JName);
        }

        private void CreateShortcut()
        {
            using (StreamWriter writer = new StreamWriter(Corelib.StartFolder + Name + ".url"))
            {
                string app = Corelib.AppsFolder + JName + "/" + exe;
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
                    Directory.SetCurrentDirectory(new FileInfo(Corelib.AppsFolder + JName + "/" + exe).Directory.FullName);
                    Process Launcher = new Process();
                    Launcher.StartInfo.FileName = Corelib.AppsFolder + JName + "/" + exe;
                    Launcher.StartInfo.Arguments = args;
                    Launcher.Start();
                    Directory.SetCurrentDirectory(currentdir);
                }
                catch (Exception ex)
                {
                    Corelib.Write(Name + " can not start" + ex);
                }
            }
        }

        public void Hash()
        {

        }
    }

    public class Config
    {
        public static string ConfigFile = Path.Combine(Corelib.MstorePath, "Mstore.config");

        [JsonProperty]
        public static bool StorePass = false;
        [JsonProperty]
        public static bool StoreSecured = false;
    }
}