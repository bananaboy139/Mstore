using System.IO;
using System.Threading.Tasks;

namespace Mstore_Log_lib
{
    public class Logger
    {
        static string LogFile = @"Mstore\log.txt";
        public static async Task Write(string text)
        {
            await File.WriteAllTextAsync(LogFile, text);
        }
    }
}
