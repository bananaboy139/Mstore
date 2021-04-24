using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Mstore_Core_lib
{
    public static class Corelib
    {
        public readonly static string StartFolder = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
        public readonly static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public readonly static string MstorePath = Path.Combine(appdata, "Mstore/");
        public readonly static string LogFile = Path.Combine(MstorePath, "Log.txt");
        public readonly static string AppsFolder = Path.Combine(MstorePath, "Apps/");
        public readonly static string PakagesFolder = Path.Combine(MstorePath, "Pakages/");
        public readonly static string DownloadsFolder = Path.Combine(MstorePath, "Downloads/");

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

        public static void ImportF(string f)
        {
            JsonSerializer serializer = new JsonSerializer();
            using StreamReader file = File.OpenText(f);
            Pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
            file.Close();
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
                List<string> ToDecrypt = new List<string>();
                foreach (string f in Directory.GetFiles(PakagesFolder, "*.aes", SearchOption.TopDirectoryOnly))
                {
                    ToDecrypt.Add(f);
                }

                foreach (string f in ToDecrypt)
                {
                    try
                    {
                        Decrypt(f);
                        File.Delete(f);
                    }
                    catch (IOException e)
                    {
                        Write(e.ToString());
                    }
                }
            }
            foreach (string f in Directory.GetFiles(PakagesFolder, "*.json", SearchOption.TopDirectoryOnly))
            {
                using StreamReader file = File.OpenText(f);
                Pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
                file.Close();
                if (Config.StoreSecured)
                {
                    Encrypt(f);
                    File.Delete(f);
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
                foreach (Pakage pakage in Pakages)
                {
                    string pakageinfo = JsonConvert.SerializeObject(pakage);
                    string FileName = PakagesFolder + pakage.JName + ".json";

                    File.WriteAllText(FileName, pakageinfo);
                    if (Config.StoreSecured)
                    {
                        Encrypt(FileName);
                        File.Delete(FileName);
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


        //encryption https://ourcodeworld.com/articles/read/471/how-to-encrypt-and-decrypt-files-using-the-aes-encryption-algorithm-in-c-sharp

        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        private static void FileEncrypt(string inputFile, string password )
        {
            byte[] salt = GenerateRandomSalt();

            FileStream fsCrypt = new FileStream(
                PakagesFolder + Path.GetFileNameWithoutExtension(inputFile) + ".aes", 
                FileMode.Create);

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;

            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //UI show some stuff
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Write("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }

        private static void FileDecrypt(string inputFile, string outputFile, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //UI show some stuff
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        private static void Encrypt(string file)
        {
            FileEncrypt(PakagesFolder + Path.GetFileNameWithoutExtension(file) + ".json", Config.MasterPass);
        }

        private static void Decrypt(string file)
        {
            FileDecrypt(PakagesFolder + Path.GetFileNameWithoutExtension(file) + ".aes",
                PakagesFolder + Path.GetFileNameWithoutExtension(file) + ".json", Config.MasterPass);
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
    }

    public class Config
    {
        public static string ConfigFile = Path.Combine(Corelib.MstorePath, "Mstore.config");

        [JsonProperty]
        public static bool StorePass = false;
        [JsonProperty]
        public static bool StoreSecured = false;

        public static string MasterPass = "master";
    }
}