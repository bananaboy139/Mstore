using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Mstore_download_lib;
using Mstore_Log_lib;

namespace Pakages
{

    class Pakage
    {
        public string Name;
        public string DownloadURL;
        public string Description;
        public string Folder;
        public string EXEPath;
        private string Path = "./Mstore/";

        public void Download()
        {
            DownloadManager.Download(URL, path + Name);
            //TODO: catch errors + extract the right zip name
            ExtractToDirectory(Path + name, Path + Folder);
            Logger.Write("Extract Complete\n " + Name + "\nLocation:  " + Path + Folder);

        }

        public void Run()
        {
            try 
            {
                Process Launcher = new Process();
                Launcher.StartInfo.FileName = EXEPath;
                Launcher.Start();
            } 
            catch (Win32Exception ex)
            {
                Logger.Write(Name + " Is NOT Downloaded");
                Directory.Delete(Folder, true)

            }

        }
    }
}
