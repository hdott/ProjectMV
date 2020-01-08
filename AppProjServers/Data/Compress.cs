using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProjServers.Data
{
    class Compress
    {
        public static byte[] Zip(byte[] data)
        {
            using (var msi = new MemoryStream(data))
            {
                using (var mso = new MemoryStream())
                {
                    using (var gs = new GZipStream(mso, CompressionMode.Compress))
                    {
                        msi.CopyTo(gs);
                    }

                    return mso.ToArray();
                }
            }
        }

        public static byte[] UnZip(byte[] data)
        {
            using (var msi = new MemoryStream(data))
            {
                using (var mso = new MemoryStream())
                {
                    using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                    {
                        gs.CopyTo(mso);
                    }

                    return mso.ToArray();
                }
            }
        }
    }
}
