using AppProj.Data;
using AppProj.Model.Login;
using AppProj.View.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProj.View
{
    public partial class RegisterForm : Form
    {
        public static UserData _data = new UserData();
        private bool firstNameCheck = false;
        private bool lastNameCheck = false;
        private bool usernameCheck = false;
        private bool passwordCheck = false;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();

            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void firstNameTextBox_Click(object sender, EventArgs e)
        {
            firstNameTextBox.SelectAll();
        }

        private void lastNameTextBox_Click(object sender, EventArgs e)
        {
            lastNameTextBox.SelectAll();
        }

        private void usernameTextBox_Click(object sender, EventArgs e)
        {
            usernameTextBox.SelectAll();
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.SelectAll();
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text.Length == 0)
            {
                firstNameConfirmationLabel.Visible = false;
                firstNameCheck = false;
            } 
            else if (firstNameTextBox.Text.Length < 3)
            {
                firstNameConfirmationLabel.ForeColor = Color.Red;
                firstNameConfirmationLabel.Text = ">= 3";
                firstNameConfirmationLabel.Visible = true;
                firstNameCheck = false;
            }
            else if (firstNameTextBox.Text.Length > 2)
            {
                firstNameConfirmationLabel.ForeColor = Color.Green;
                firstNameConfirmationLabel.Text = "Good";
                firstNameConfirmationLabel.Visible = true;
                firstNameCheck = true;
                _data.FirstName = firstNameTextBox.Text;
            }

            if (firstNameCheck &&
                lastNameCheck &&
                usernameCheck &&
                passwordCheck)
            {
                createAccountButton.Enabled = true;
            }
            else
            {
                createAccountButton.Enabled = false;
            }
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lastNameTextBox.Text.Length == 0)
            {
                lastNameConfirmationLabel.Visible = false;
                lastNameCheck = false;
            }
            else if (lastNameTextBox.Text.Length < 3)
            {
                lastNameConfirmationLabel.ForeColor = Color.Red;
                lastNameConfirmationLabel.Text = ">= 3";
                lastNameConfirmationLabel.Visible = true;
                lastNameCheck = false;
            }
            else if (lastNameTextBox.Text.Length > 2)
            {
                lastNameConfirmationLabel.ForeColor = Color.Green;
                lastNameConfirmationLabel.Text = "Good";
                lastNameConfirmationLabel.Visible = true;
                lastNameCheck = true;
                _data.LastName = lastNameTextBox.Text;
            }

            if (firstNameCheck &&
                lastNameCheck &&
                usernameCheck &&
                passwordCheck)
            {
                createAccountButton.Enabled = true;
            }
            else
            {
                createAccountButton.Enabled = false;
            }
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (usernameTextBox.Text.Length == 0)
            {
                usernameConfirmationLabel.Visible = false;
                usernameCheck = false;
            }
            else if (usernameTextBox.Text.Length < 4)
            {
                usernameConfirmationLabel.ForeColor = Color.Red;
                usernameConfirmationLabel.Text = ">= 4";
                usernameConfirmationLabel.Visible = true;
                usernameCheck = false;
            }
            else if (usernameTextBox.Text.Length > 3)
            {
                usernameConfirmationLabel.ForeColor = Color.Green;
                usernameConfirmationLabel.Text = "Good";
                usernameConfirmationLabel.Visible = true;
                usernameCheck = true;
                _data.Username = usernameTextBox.Text;
            }

            if (firstNameCheck && 
                lastNameCheck &&
                usernameCheck &&
                passwordCheck)
            {
                createAccountButton.Enabled = true;
            }
            else
            {
                createAccountButton.Enabled = false;
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            Assembly hash = Assembly.LoadFrom("HashingAssembly.dll");
            Type type = hash.GetType("HashingAssembly.HashString");
            MethodInfo method = type.GetMethod("ComputeSha256Hash");
            object instance = Activator.CreateInstance(type);
            var rez = method.Invoke(instance, new object[] { passwordTextBox.Text });


            if (passwordTextBox.Text.Length == 0)
            {
                passwordConfirmationLabel.Visible = false;
                passwordCheck = false;
            }
            else if (passwordTextBox.Text.Length < 8)
            {
                passwordConfirmationLabel.ForeColor = Color.Red;
                passwordConfirmationLabel.Text = ">= 8";
                passwordConfirmationLabel.Visible = true;
                passwordCheck = false;
            }
            else if (passwordTextBox.Text.Length > 7)
            {
                passwordConfirmationLabel.ForeColor = Color.Green;
                passwordConfirmationLabel.Text = "Good";
                passwordConfirmationLabel.Visible = true;
                passwordCheck = true;
                _data.Password = rez.ToString();
            }

            if (firstNameCheck &&
                lastNameCheck &&
                usernameCheck &&
                passwordCheck)
            {
                createAccountButton.Enabled = true;
            }
            else
            {
                createAccountButton.Enabled = false;
            }
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            RegisterModel register = new RegisterModel();
            register.RegisterProcess(_data);

            LogInModel login = new LogInModel();
            LogInData loginData = new LogInData();
            LogInData.ViaAction = "REGISTER";

            loginData.Username = _data.Username;
            loginData.Password = _data.Password;

            bool isConnected = login.LogInProcess(loginData);
            if (isConnected)
            {
                notificationLabel.ForeColor = Color.Green;
                notificationLabel.Text = "Connected";
                notificationLabel.Visible = true;
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
    }
}
