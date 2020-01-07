using AppProj.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AppProj.Model.Login;
using AppProj.View.Graphics;
using System.Threading;
using AppProj.View;
using System.Xml;

namespace AppProj
{
    public partial class LoginForm : Form
    {
        private LogInData _data = new LogInData();

        public LoginForm()
        {
            InitializeComponent();

            //if (File.Exists("rememberMe.xml"))
            //{
            //    XmlTextReader textReader = new XmlTextReader("rememberMe.xml");

            //    while (textReader.Read())
            //    {
            //        switch (textReader.NodeType)
            //        {
            //            case XmlNodeType.Element:

            //                if (textReader.Name == "Username")
            //                {
            //                    usernameTextBox.Text = textReader.GetAttribute("Username");
            //                }
            //                if (textReader.Name == "Checked")
            //                {
            //                    rememberMeCheckBox.Checked = bool.Parse(textReader.GetAttribute("Checked"));
            //                }
            //                break;

            //            case XmlNodeType.EndElement:
            //                break;

            //            case XmlNodeType.Text:
            //                break;
            //        }
                    
            //    }

            //    //if (bool.Parse(textReader.ReadString()))
            //    //{
            //    //    rememberMeCheckBox.Checked = true;
            //    //}
            //    //else
            //    //{
            //    //    rememberMeCheckBox.Checked = false;
            //    //}
            //}
        }

        private void usernameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            usernameTextBox.SelectAll();
        }

        private void passwordTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            passwordTextBox.SelectAll();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            LogInModel model = new LogInModel();

            bool isConnected = model.LogInProcess(_data);
            if (isConnected)
            {
                welcomeLabel.Location = new Point(welcomeLabel.Location.X - usernameTextBox.Text.Length,
                                                    welcomeLabel.Location.Y);
                welcomeLabel.Text = "Welcome, " + usernameTextBox.Text;

                notificationLabel.ForeColor = Color.Green;
                notificationLabel.Text = "Connected";
                notificationLabel.Visible = true;

                //if (rememberMeCheckBox.Checked)
                //{
                //    XmlTextWriter textWriter = new XmlTextWriter("rememberMe.xml", null);
                //    textWriter.WriteStartDocument();
                //    textWriter.WriteWhitespace("\n");

                //    textWriter.WriteStartElement("Username");
                //    //textWriter.WriteAttributeString("Username", _data.Username);
                //    textWriter.WriteWhitespace("\n\t");
                //    textWriter.WriteElementString("Username", _data.Username);
                //    textWriter.WriteEndElement();

                //    textWriter.WriteStartElement("Checked");
                //    textWriter.WriteWhitespace("\n\t");
                //    textWriter.WriteElementString("Checked", "true");
                //    textWriter.WriteEndElement();

                //    textWriter.WriteEndDocument();
                //    textWriter.Flush();
                //    textWriter.Close();
                //}
                //else
                //{
                //    XmlTextWriter textWriter = new XmlTextWriter("rememberMe.xml", null);
                //    textWriter.WriteStartDocument();
                //    textWriter.WriteWhitespace("\n");

                //    textWriter.WriteStartElement("Username");
                //    //textWriter.WriteAttributeString("Username", _data.Username);
                //    textWriter.WriteWhitespace("\n\t");
                //    textWriter.WriteElementString("Username", "Username");
                //    textWriter.WriteEndElement();

                //    textWriter.WriteStartElement("Checked");
                //    textWriter.WriteWhitespace("\n\t");
                //    textWriter.WriteElementString("Checked", "false");
                //    textWriter.WriteEndElement();

                //    textWriter.WriteEndDocument();
                //    textWriter.Flush();
                //    textWriter.Close();
                //}
            }
            else
            {
                notificationLabel.ForeColor = Color.Red;
                notificationLabel.Text = "Account does NOT Exist!";
                notificationLabel.Visible = true;
            }


            var loadingBar = new LoadingBar();
            loadingBar.Activate(131, 383, this);
            Refresh();
            notificationLabel.Visible = false;
            if (isConnected)
            {
                Close();
                Dispose();

                AppProjForm appProjForm = new AppProjForm();
                appProjForm.ShowDialog();
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            //notificationLabel.Visible = true;

            Assembly hash = Assembly.LoadFrom("HashingAssembly.dll");
            Type type = hash.GetType("HashingAssembly.HashString");
            MethodInfo method = type.GetMethod("ComputeSha256Hash");
            object instance = Activator.CreateInstance(type);
            var rez = method.Invoke(instance, new object[] { passwordTextBox.Text });

            _data.Password = rez.ToString();
            
            //usernameTextBox.Text = client.SendMessageFromClient(rez.ToString());
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            _data.Username = usernameTextBox.Text;
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            //LoadingBar loadingBar = new LoadingBar();
            //loadingBar.LoadingBarPaint(sender, e);

            
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();

            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void rememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
