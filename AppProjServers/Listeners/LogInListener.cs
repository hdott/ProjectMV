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
    public class LogInListener
    {
        private static LogInListener instance = null;
        private static readonly object padlock = new object();
        private static TcpListener server = null;
        
        private LogInListener()
        {
            Int32 port = 55555;
            IPAddress addr = IPAddress.Parse("192.168.0.153");

            server = new TcpListener(addr, port);
            server.Start();
        }

        public static LogInListener Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LogInListener();
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
            //bool _tr = true;
            //do
            //{
                
            //} while (_tr);

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


                    //data = null;

                    //NetworkStream stream = client.GetStream();

                    //int i
                    string responseMsg = null;
                    byte[] _data = new byte[128];
                    try
                    {
                        stream.Read(_data, 0, _data.Length);

                        if (_data == null) break;
                        /// Decription
                        //Console.WriteLine(_data.Length);
                        string privateKey = (string)getPrivateKey.Invoke(instance, null);

                        byte[] decriptedData = (byte[])Decription.Invoke(instance, new object[] { (string)getPrivateKey.Invoke(instance, null) ,
                                                                            _data });

                        /// Deserialization of Object
                        LogInData logInData = LogInData.Deserialize(decriptedData);
                        //Console.WriteLine("Username: {0}", logInData.Username);
                        //Console.WriteLine("Password: {0}", logInData.Password);

                        if (db.AuthenticateUser(logInData.Username,
                                                logInData.Password))
                        {
                            responseMsg = "OK";
                        }
                        else
                        {
                            responseMsg = "NOT";
                        }


                        byte[] response = System.Text.Encoding.ASCII.GetBytes(responseMsg);
                        stream.Write(response, 0, response.Length);
                    }
                    catch (Exception ex)
                    {
                        ;
                    }

                    //while((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    //{
                    //    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    //    Console.WriteLine("Received: {0}", data);

                    //    data = data.ToUpper();

                    //    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    //    stream.Write(msg, 0, msg.Length);
                    //    Console.WriteLine("Sent: {0}", data);
                    //}



                    //client.Close();
                }

            }
        }
    }
}
