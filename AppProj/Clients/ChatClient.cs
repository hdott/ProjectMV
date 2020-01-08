using AppProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProj.Clients
{
    public class ChatClient
    {
        public static TextBox Output { get; set; }
        private static ChatClient instance = null;
        private static readonly object padlock = new object();

        private string _server = "79.119.218.35";
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

        private byte[] _publicKeyToEncrypt = new byte[256];
        private byte[] _publicKeyToGive = new byte[256];
        private ManualResetEvent _threadControl = new ManualResetEvent(true);

        public ChatClient()
        {
            client = new TcpClient(_server, _port);
            stream = client.GetStream();

            //Thread t = new Thread(new ThreadStart(() => Listener()));
            //t.Start();
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

        public void SendMessage(byte[] data, Int32 action)
        {
            _threadControl.Reset();

            switch (action)
            {
                case ChatDataConstants.GeneralChat:

                    if (getToken)
                    {
                        stream.Read(_publicKeyToEncrypt, 0, _publicKeyToEncrypt.Length);
                        _token = System.Text.Encoding.ASCII.GetString(_publicKeyToEncrypt);

                        encript = Assembly.LoadFrom("AsymmetricEncriptionAssembly.dll");
                        type = encript.GetType("AsymmetricEncriptionAssembly.AsymmetricEncription");
                        Encription = type.GetMethod("Encription");
                        instanceEncript = Activator.CreateInstance(type);

                        getToken = false;
                    }

                    Console.WriteLine(data.Length);
                    var _data = Compress.Zip(data);

                    Console.WriteLine(_data.Length);
                    _data = (byte[])Encription.Invoke(instanceEncript, new object[] { _token, _data });

                    Console.WriteLine(_data.Length);
                    stream.Write(_data, 0, _data.Length);
                    break;
            }

            

            _threadControl.Set();
        }

        public void Listener()
        {
            while (true)
            {

                _threadControl.WaitOne(Timeout.Infinite);
            }
        }
    }
}
