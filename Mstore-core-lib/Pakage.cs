using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Mstore_download_lib;
using Mstore_Log_lib;
using System.ComponentModel;

namespace Pakages
{

    public class Pakage
    {
        public string Name;
        public string DownloadURL;
        public string Description;
        public string Folder;
        public string EXEPath;
        private string Path = "./Mstore/";
        public string JName;

        public async void Download()
        {
            DownloadManager.Download(DownloadURL, Path + Name);
            //TODO: catch errors + extract the right zip name
            ZipFile.ExtractToDirectory(Path + Name, Path + Folder);
            await Logger.Write("Extract Complete\n " + Name + "\nLocation:  " + Path + Folder);

        }

        public async void Run()
        {
            try 
            {
                Process Launcher = new Process();
                Launcher.StartInfo.FileName = EXEPath;
                Launcher.Start();
            } 
            catch (Win32Exception ex)
            {
                await Logger.Write(Name + " Is NOT Downloaded" + ex);
                Directory.Delete(Folder, true);

            }

        }
    }
}
