using System;
using System.Diagnostics;
using Mstore_download_lib;


namespace Pakages
{

    class Pakage
    {
        public string Name;
        public string DownloadURL;
        public string Description;
        public string EXEPath;
        private string Path;

        public void Download()
        {
            lib.download(URL, Path);
        }

        public void Run()
        {
            Process Launcher = new Process();
            Launcher.StartInfo.FileName = EXEPath;
            Launcher.Start();
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
