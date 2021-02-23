using Mstore_Core_lib;
using System.Collections.Generic;
using Pakages;

namespace Mstore_Console
{
    class Program
    {
        static Corelib Lib = new Corelib();
        static List<Pakage> Pakages;
        static void Main(string[] args)
        {
            import();
            export();
        }

        static void import ()
        {
            Pakages = Lib.ImportList(Lib.path);
        }

        static void export ()
        {
            Lib.ExportList(Pakages);
        }

    }
}
