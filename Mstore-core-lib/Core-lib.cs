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
		public readonly static string StartFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "Programs/Mstore/");
		public readonly static string UserDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		public readonly static string MstorePath = Path.Combine(UserDir, ".Mstore/");
		public readonly static string LogFile = Path.Combine(MstorePath, "Log.txt");
		public readonly static string AppsFolder = Path.Combine(MstorePath, "Apps/");
		public readonly static string PakagesFolder = Path.Combine(MstorePath, "Pakages/");
        public static readonly string DownloadsFolder = Path.Combine(MstorePath, "Downloads/");

        public static List<Pakage> Pakages = new();

		public static Pakage Current;

		public static Pakage Downloading;

		/// creates all the folders needed by Mstore
		public static void Setup()
		{
			string[] Dirs = { MstorePath, AppsFolder, PakagesFolder, StartFolder, DownloadsFolder };

			foreach (string dir in Dirs)
			{
				if (!Directory.Exists(dir))
				{
					Directory.CreateDirectory(dir);
				}
			}
		}

		public static void ImportF(string f)
		{
			JsonSerializer serializer = new();
			using StreamReader file = File.OpenText(f);
			Pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
			file.Close();
		}

		public static void Import()
		{
			//Removes all nameless files that might be imported
			string[] badfile =
			{
				Path.Combine(PakagesFolder,".json"),
				Path.Combine(PakagesFolder, " .json")
			};
			foreach (string file in badfile)
			{
				if (File.Exists(file))
				{
					File.Delete(file);
				}
			}
			Pakages.Clear();
			//read pakage files
			JsonSerializer serializer = new();
			foreach (string f in Directory.GetFiles(PakagesFolder, "*.json", SearchOption.TopDirectoryOnly))
			{
				using StreamReader file = File.OpenText(f);
				Pakages.Add((Pakage)serializer.Deserialize(file, typeof(Pakage)));
				file.Close();
			}
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

			//check if installed
			foreach (Pakage p in Pakages)
			{
				p.IsInstalled = Directory.Exists(AppsFolder + p.JName + "/");
			}
		}

		public static void ExportList()
		{
			try
			{
				foreach (Pakage pakage in Pakages)
				{
					string pakageinfo = JsonConvert.SerializeObject(pakage);
					string FileName = MstorePath + "Pakages/" + pakage.JName + ".json";

					File.WriteAllText(FileName, pakageinfo);
				}

				//export config
				Config c = new();
				string Configuration = JsonConvert.SerializeObject(c);
				File.WriteAllText(Config.ConfigFile, Configuration);
			}
			catch (Exception e)
			{
				Write(e.ToString());
				throw new Exception(e.ToString());
			}
		}
		//writes to log
		public static void Write(string t)
		{
			DateTime dateToDisplay = new();
			string text = dateToDisplay.ToString() + ":   " + t + "\n";
			File.AppendAllText(LogFile, text);
		}

		public static void ClearDownloadsFolder()
		{
			foreach (string f in Directory.GetFiles(DownloadsFolder))
			{
				Write("Deleting downloads file: " + f);
				File.Delete(f);
			}
			foreach (string d in Directory.GetDirectories(DownloadsFolder))
			{
				Write("Deleting downloads Folder: " + d);
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

		[JsonIgnore]
		public bool IsInstalled = false;

		public static bool ShouldSerializePassword()
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
		}

		public void CreateShortcut()
		{
			IWshRuntimeLibrary.WshShell shell = new();
			string shortcutAddress = Corelib.StartFolder + Name + ".lnk";
			IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutAddress);
			shortcut.WorkingDirectory = new FileInfo(Corelib.AppsFolder + JName + "/" + exe).Directory.FullName;
			shortcut.Arguments = args;
			shortcut.TargetPath = Corelib.AppsFolder + JName + "/" + exe;
			shortcut.IconLocation = Corelib.AppsFolder + JName + "/" + exe;
			shortcut.Save();
		}

		public void Run()
		{
			if (IsInstalled)
			{
				var currentdir = Directory.GetCurrentDirectory();
				try
				{
					Directory.SetCurrentDirectory(new FileInfo(Corelib.AppsFolder + JName + "/" + exe).Directory.FullName);
					Process Launcher = new();
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
        public static bool StorePass = true;

		public static bool StoreEncrypted = false;
	}
}