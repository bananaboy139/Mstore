using System;
using System.IO;
using Mstore_Var;

namespace Mstore_Log_lib
{
    public class Logger
    {
        static string LogFile = Var.LogFile;
        public static void Write(string t)
        {
            DateTime dateToDisplay = new DateTime();
            string text = dateToDisplay.ToString() + ":   " + t + "\n";
            File.AppendAllText(LogFile, text);
        }
    }

}
