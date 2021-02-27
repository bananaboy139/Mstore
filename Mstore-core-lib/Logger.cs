using System;
using System.IO;
using Mstore_Var;

namespace Mstore_Log_lib
{
    public class Logger
    {
        static string LogFile = Var.LogFile;
        public static void Write(string text)
        {
            File.AppendAllText(LogFile, text);
        }
    }

}
