using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProj.Clients
{
    public class ChatClient
    {
        public static TextBox Output { get; set; }
        private static ChatClient instance = null;
        private static readonly object padlock = new object();

        private string _server = "192.168.0.153";
        private Int32 _port = 55557;
        TcpClient client = null;
        NetworkStream stream = null;
        private string _token = null;
        private bool getToken = true;
        private Assembly encript = null;
        private Type type = null;
        private MethodInfo Encription = null;
        private MethodInfo Decription = null;
        private object instanceEncript = null;

        public ChatClient()
        {
            client = new TcpClient(_server, _port);
            stream = client.GetStream();
        }

        public static ChatClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ChatClient();
                    }
                }

                return instance;
            }
        }

        public void SendMessage(byte[] data)
        {
            if (getToken)
            {
                byte[] publicKey = new byte[256];
                stream.Read(publicKey, 0, publicKey.Length);
                _token = System.Text.Encoding.ASCII.GetString(publicKey);

                encript = Assembly.LoadFrom("AsymmetricEncriptionAssembly.dll");
                type = encript.GetType("AsymmetricEncriptionAssembly.AsymmetricEncription");
                Encription = type.GetMethod("Encription");
                instanceEncript = Activator.CreateInstance(type);

                getToken = false;
            }

            data = (byte[])Encription.Invoke(instanceEncript, new object[] { _token, data });

            Console.WriteLine(data.Length);
            stream.Write(data, 0, data.Length);
        }

        public void Listener()
        {

        }
    }
}
