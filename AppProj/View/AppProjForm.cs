using AppProj.Clients;
using AppProj.Data;
using AppProj.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProj.View
{
    public partial class AppProjForm : Form
    {
        private ChatData _data = new ChatData();
        public AppProjForm()
        {
            InitializeComponent();

            //ChatClient.Output = chatOutputTextBox;
            chatInputTextBox.Focus();
        }

        private void AppProjForm_Load(object sender, EventArgs e)
        {
            if (LogInData.ViaAction.Contains("LOGIN"))
            {
                toolStripMenuItem1.Text = LoginForm._data.Username;
            }
            else
            {
                toolStripMenuItem1.Text = RegisterForm._data.Username;
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();

            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void chatInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _data.Action = ChatDataConstants.GeneralChat;
                _data.Message = chatInputTextBox.Text;
                _data.Date = DateTime.Now.ToString();
                _data.TargetUser = "none";
                ChatModel model = new ChatModel();
                model.SendMessage(_data, _data.Action);
                e.SuppressKeyPress = true;

                chatInputTextBox.Clear();
            }
        }
    }
}
