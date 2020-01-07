using AppProj.Clients;
using AppProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProj.Model
{
    class ChatModel
    {
        public void SendMessage(ChatData data, TextBox output)
        {
            byte[] _data = data.Serialize();

            ChatClient.Instance.SendMessage(_data);

        }
    }
}
