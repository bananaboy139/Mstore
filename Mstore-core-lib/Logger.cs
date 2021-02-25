using System;
using System.IO;


namespace Mstore_Log_lib
{
    public class Var
    {
        public static string Path = @"C:/Mstore/";

    }

    public class Logger
    {
        static string LogFile = Var.Path + "Log.txt";
        public static void Write(string text)
        {
            File.AppendAllText(LogFile, text);
        }
    }

}
