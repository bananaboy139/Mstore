using System.IO.Compression;
using System.Diagnostics;
using Mstore_Log_lib;
using System.ComponentModel;
using System.IO;
namespace Pakages
{

    public class Pakage
    {
        public string Name;
        public string DownloadURL;
        public string Description;
        public string JName;
        public string exe;
        public string args;
        private string Path = Var.Path;
        public bool IsInstalled = false;

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
}
