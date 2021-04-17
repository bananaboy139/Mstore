using System;
using System.IO;

namespace Mstore_Var
{
    public static class Var
    {
        public static string appdata = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData);
        public static string MstorePath = Path.Combine(appdata, "Mstore/");
    }
}