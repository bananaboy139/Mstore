using System;
using System.IO;

namespace Mstore_Var
{
    public class Var
    {
        public static string path;
        public static string appdata = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), "Mstore.settings");
    }
}
