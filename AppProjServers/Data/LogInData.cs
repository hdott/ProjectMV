using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProjServers.Data
{
    public class LogInData
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Username);
                    writer.Write(Password);
                }

                return m.ToArray();
            }
        }

        public static LogInData Deserialize(byte[] data)
        {
            LogInData obj = new LogInData();

            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    obj.Username = reader.ReadString();
                    obj.Password = reader.ReadString();
                }
            }

            return obj;
        }
    }
}
