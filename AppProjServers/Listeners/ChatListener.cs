using AppProjServers.Connexions;
using AppProjServers.Data;
using AppProjServers.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppProjServers.Listeners
{
    public class ChatListener
    {
        private static ChatListener instance = null;
        private static readonly object padlock = new object();
        private static TcpListener server = null;
        private static OnlineConnexions onlineConnexions = OnlineConnexions.Instance;

        private ChatListener()
        {
            Int32 port = 55557;
            //IPAddress addr = IPAddress.Parse("5.15.37.169");

            server = new TcpListener(port);
            server.Start();
        }

        public static ChatListener Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ChatListener();
                    }
                }

                return instance;
            }
        }

        public void Listener()
        {
            TcpClient client = null;
            //NetworkStream stream = null;
            //Assembly encript = null;
            //Type type = null;
            //MethodInfo getPublicKey = null;
            //MethodInfo getPrivateKey = null;
            //MethodInfo Decription = null;
            //object instance = null;

            //bool justConnected;
            //bool _tr = true;
            //do
            //{

            //} while (_tr);

            Byte[] bytes = new Byte[256];
            String data = null;

            while (true)
            {
                Console.WriteLine("Waiting for connection... ");
                //Thread tmsg = new Thread(() => Output.Instance.AppendMsg("Waiting for connection... "));
                //tmsg.Start();
                client = server.AcceptTcpClient();

                Thread t = new Thread(() => LogInProcess(client));
                t.Start();
            }
        }

        private void LogInProcess(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            Assembly encript = Assembly.LoadFrom("AsymmetricEncriptionAssembly.dll");
            Type type = encript.GetType("AsymmetricEncriptionAssembly.AsymmetricEncription");
            MethodInfo getPublicKey = type.GetMethod("getPublicKey");
            MethodInfo getPrivateKey = type.GetMethod("getPrivateKey");
            MethodInfo Decription = type.GetMethod("Decription");
            object instance = Activator.CreateInstance(type);

            Database db = Database.Instance;
            db.ConnectToDb();

            bool justConnected = true;

            ChatData chatData = null;
            while (client.Connected)
            {
                //TcpClient client = server.AcceptTcpClient();
                //Console.WriteLine("Connected!");
                //if (justConnected)
                //{
                //    //Thread tmsg = new Thread(() => Output.Instance.AppendMsg("Connected!"));
                //    //tmsg.Start();
                //    Output.Instance.AppendMsg("Connected!");
                //}
                //Output.Instance.AppendMsg("Connected!");

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

                    var uncompressedData = Compress.UnZip(decriptedData);
                    /// Deserialization of Object
                    chatData = ChatData.Deserialize(uncompressedData);

                    Console.WriteLine(chatData.Action + " " +
                                    chatData.Date + " " +
                                    chatData.Message + " " +
                                    chatData.TargetUser);
                    //if (db.AuthenticateUser(logInData.Username,
                    //                        logInData.Password))
                    //{
                    //    responseMsg = "OK";
                    //    //Console.WriteLine(DateTime.Now + $" -> {logInData.Username} Logged In\n");
                    //    //Output.Instance.AppendMsg(DateTime.Now + $" -> {logInData.Username} Logged In\n");

                    //    //onlineConnexions.UserConnected(new User
                    //    //{
                    //    //    Username = logInData.Username,
                    //    //    conn = client
                    //    //});
                    //}
                    //else
                    //{
                    //    responseMsg = "NOT";
                    //}


                    //byte[] response = System.Text.Encoding.ASCII.GetBytes(responseMsg);
                    //stream.Write(response, 0, response.Length);

                    //if (responseMsg.Contains("OK"))
                    //{
                    //    client.Close();
                    //}
                    //client.Close();
                    //Console.WriteLine("Disconnected!");
                    //Output.Instance.AppendMsg("Disconnected!");
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
            //Console.WriteLine(DateTime.Now + $" -> {logInData.Username} Disconnected\n");
            //Output.Instance.AppendMsg(DateTime.Now + $" -> {logInData.Username} Disconnected\n");
        }
    }
}
