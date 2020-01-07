using AppProjServers.Data;
using AppProjServers.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppProjServers.Listeners
{
    public class RegisterListener
    {
        private static RegisterListener instance = null;
        private static readonly object padlock = new object();
        private static TcpListener server = null;

        private RegisterListener()
        {
            Int32 port = 55556;
            IPAddress addr = IPAddress.Parse("192.168.0.153");

            server = new TcpListener(addr, port);
            server.Start();
        }

        public static RegisterListener Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RegisterListener();
                    }
                }

                return instance;
            }
        }

        public void Listener()
        {
            TcpClient client = null;
            NetworkStream stream = null;
            Assembly encript = null;
            Type type = null;
            MethodInfo getPublicKey = null;
            MethodInfo getPrivateKey = null;
            MethodInfo Decription = null;
            object instance = null;

            bool justConnected;

            Byte[] bytes = new Byte[256];
            String data = null;

            while (true)
            {
                Console.WriteLine("Waiting for connection... ");
                client = server.AcceptTcpClient();
                stream = client.GetStream();
                //_tr = false;

                encript = Assembly.LoadFrom("AsymmetricEncriptionAssembly.dll");
                type = encript.GetType("AsymmetricEncriptionAssembly.AsymmetricEncription");
                getPublicKey = type.GetMethod("getPublicKey");
                getPrivateKey = type.GetMethod("getPrivateKey");
                Decription = type.GetMethod("Decription");
                instance = Activator.CreateInstance(type);

                Database db = Database.Instance;
                db.ConnectToDb();
                

                justConnected = true;

                while (client.Connected)
                {
                    //TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    /// Encription client sided
                    if (justConnected)
                    {
                        string publicKey = (string)getPublicKey.Invoke(instance, null);
                        byte[] token = System.Text.Encoding.ASCII.GetBytes(publicKey);

                        Console.WriteLine(token.Length);
                        stream.Write(token, 0, token.Length);
                        justConnected = false;
                    }

                    byte[] _data = new byte[128];
                    try
                    {
                        stream.Read(_data, 0, _data.Length);

                        /// Decription
                        Console.WriteLine(_data.Length);
                        string privateKey = (string)getPrivateKey.Invoke(instance, null);
                        _data = (byte[])Decription.Invoke(instance, new object[] { (string)getPrivateKey.Invoke(instance, null) ,
                                                                            _data });

                        /// Deserialization of Object
                        UserData registerData = UserData.Deserialize(_data);

                        db.AddUser(registerData.FirstName,
                                    registerData.LastName,
                                    registerData.Username,
                                    registerData.Password);

                        //Console.WriteLine("Username: {0}", logInData.Username);
                        //Console.WriteLine("Password: {0}", logInData.Password);
                    }
                    catch (Exception ex)
                    {
                        ;
                    }
                }

            }
        }
    }
}
