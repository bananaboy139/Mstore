using Mstore_Core_lib;
using System.Collections.Generic;
using Pakages;
using System;

namespace Mstore_Console
{
    class Program
    {
        static Corelib Lib = new Corelib();
        static List<Pakage> Pakages = new List<Pakage>();
        static void Main(string[] args)
        {
            import();
            foreach (Pakage s in Pakages)
            {
                Console.WriteLine(s.Name);
            }
        }

        static void import() => Pakages = Lib.Import(Lib.path);

        static void export() => Lib.ExportList(Pakages);

    }
}
