using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppProjServers.Connexions
{
    public class User
    {
        public string Username { get; set; }
        public TcpClient conn { get; set; }
    }
}
