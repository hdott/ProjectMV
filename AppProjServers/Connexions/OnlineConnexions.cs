using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProjServers.Connexions
{
    class OnlineConnexions
    {
        private static OnlineConnexions instance = null;
        private static readonly object padlock = new object();
        private static List<User> connectedUsers = new List<User>();

        public static OnlineConnexions Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new OnlineConnexions();
                    }

                    return instance;
                }

            }
        }

        public void UserConnected(User user)
        {
            connectedUsers.Add(user);
        }

        public void UserDisconnected(User user)
        {
            connectedUsers.Remove(user);
        }
    }
}
