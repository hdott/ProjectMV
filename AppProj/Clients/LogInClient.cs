using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppProj.Clients
{
    public class LogInClient
    {
        private static LogInClient instance = null;
        private static readonly object padlock = new object();
        
        private string _server = "192.168.0.153";
        private Int32 _port = 55555;
        TcpClient client = null;
        NetworkStream stream = null;
        private string _token = null;
        private bool getToken = true;
        private Assembly encript = null;
        private Type type = null;
        private MethodInfo Encription = null;
        private object instanceEncript = null;

        public LogInClient()
        {
            client = new TcpClient(_server, _port);
            stream = client.GetStream();
        }

        public static LogInClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LogInClient();
                    }
                }

                return instance;
            }
        }

        public string SendMessageFromClient(string msg)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);
            
            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", msg);

            data = new Byte[256];

            String responseData = String.Empty;

            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            //stream.Close();
            //client.Close();
            return responseData;
        }



        public bool LogIn(byte[] data)
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

            data = (byte[])Encription.Invoke(instanceEncript, new object[] { _token , data});

            //Console.WriteLine(data.Length);
            stream.Write(data, 0, data.Length);

            byte[] auth = new byte[256];
            stream.Read(auth, 0, auth.Length);

            if (System.Text.Encoding.ASCII.GetString(auth).Contains("OK"))
            {
                return true;
            }
            else
            {
                return false;
            }
            /// Testing purposes
            //data = new Byte[256];

            //String responseData = String.Empty;

            //Int32 bytes = stream.Read(data, 0, data.Length);
            //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            //Console.WriteLine("Received: {0}", responseData);
        }
    }
}
