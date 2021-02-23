using System;
using Mstore_Core_lib;
using Pakages;

namespace Mstore_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Corelib Lib = new Corelib();
            Pakage[] pakages = Lib.ImportList(Lib.path).ToArray();
            Console.WriteLine(pakages.Length);
            Console.WriteLine(pakages[0].Name);
            Console.ReadLine();
        }
    }
}
