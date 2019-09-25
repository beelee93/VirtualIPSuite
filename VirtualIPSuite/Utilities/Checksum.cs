using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualIPSuite.Utilities
{
    public class Checksum
    {
        private static Checksum _instance = null;
        public static Checksum Instance 
        {
            get {
                if (_instance == null) _instance = new Checksum();
                return _instance;
            }
        }

        private uint[] _crcTable;

        private Checksum()
        {
            GenerateCRCLookupTable();
        }

        private void GenerateCRCLookupTable()
        {
            Logger.Instance.LogWriter.Verbose("Generating CRC Lookup Table");

            _crcTable = new uint[256];

            uint seed = 0xEDB88320u;

            for(uint i=0;i<256;i++)
            {
                uint chk = i;
                for(uint bit=0;bit<8;bit++)
                    chk = (chk >> 1) ^ ((chk & 0x1u) != 0 ? seed : 0 );
                _crcTable[i] = chk;
            }

            Logger.Instance.LogWriter.Verbose("Generated CRC Lookup Table");
        }

        public uint CRC(byte[] bytes)
        {
            uint chk = 0xFFFFFFFFu;
            foreach(byte b in bytes)
                chk = _crcTable[(chk & 0xFFu) ^ b] ^ (chk >> 8);
            return chk ^ 0xFFFFFFFFu;
        }

        public uint CRC(string input)
        {
            return CRC(Encoding.ASCII.GetBytes(input));
        }
    }
}
