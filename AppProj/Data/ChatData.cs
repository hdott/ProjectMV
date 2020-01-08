using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProj.Data
{
    class ChatData
    {
        public Int32 Action { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string TargetUser { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Action);
                    writer.Write(Message);
                    writer.Write(Date);
                    writer.Write(TargetUser);
                }

                return m.ToArray();
            }
        }

        public static ChatData Deserialize(byte[] data)
        {
            ChatData obj = new ChatData();

            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    obj.Action = reader.ReadInt32();
                    obj.Message = reader.ReadString();
                    obj.Date = reader.ReadString();
                    obj.TargetUser = reader.ReadString();
                }
            }

            return obj;
        }
    }
}
