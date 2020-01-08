using AppProjServers.Listeners;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProjServers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Output.Instance.setOutput(this);

            Thread tLogInListener = new Thread(new ThreadStart(LogInListenerWork));
            tLogInListener.Start();

            Thread tRegisterListener = new Thread(new ThreadStart(RegisterListenerWork));
            tRegisterListener.Start();

            Thread tChatListener = new Thread(new ThreadStart(ChatListenerWork));
            tChatListener.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void LogInListenerWork()
        {
            LogInListener listenLogIn = LogInListener.Instance;
            listenLogIn.Listener();
        }

        void RegisterListenerWork()
        {
            RegisterListener listenRegister = RegisterListener.Instance;
            listenRegister.Listener();
        }
        void ChatListenerWork()
        {
            ChatListener listenChat = ChatListener.Instance;
            listenChat.Listener();
        }

        private delegate void AppendMsg(string msg);
        public void OutputMsg(string msg)
        {
            if (this.InvokeRequired)
            {
                AppendMsg del = new AppendMsg(OutputMsg);
                this.Invoke(del, new object[] { msg });
            }
            else
            {
                string newline = Environment.NewLine;
                textBox1.AppendText(msg + newline);
            }
        }
    }
}
