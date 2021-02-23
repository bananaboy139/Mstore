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
        private string Path;

        public void Download()
        {
            lib.download(URL, Path);
            //TODO: catch errors
            ExtractToDirectory(Path, Path + Folder);
            Logger.Write("Extract Complete\n " + Name + "\nLocation:  " + Path + Folder);

        }

        public void Run()
        {
            try 
            {
                Process Launcher = new Process();
                Launcher.StartInfo.FileName = EXEPath;
                Launcher.Start();
            } catch (Win32Exception ex)
            {
                Logger.Write(Name + " Is NOT Downloaded");
                Directory.Delete(Folder, true)

            }

        }
    }

    class lib
    {
        public static void download(string URL, string path)
        {
            DownloadManager.URL = URL;
            DownloadManager.DownloadLocation = path;
            DownloadManager.Download();
            DownloadManager.URL = null;
            DownloadManager.DownloadLocation = null;
        }
    }
}
