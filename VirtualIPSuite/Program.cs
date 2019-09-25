using System;
using VirtualIPSuite.Utilities;

namespace VirtualIPSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            var crc32 = Checksum.Instance.CRC("123456789");
            Logger.Instance.LogWriter.Verbose(crc32.ToString("X"));
        }
    }
}
