using System;
using System.IO;

namespace Mstore_Var
{
    public class Var
    {
        public static string Path = @"C:/Mstore/";
        public static string LogFile = Path + "Log.txt";
        public static string appdata = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + "Mstore.settings";
    }
}
