using AppProjServers.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProjServers
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread tLogInListener = new Thread(new ThreadStart(LogInListenerWork));
            tLogInListener.Start();

            Thread tRegisterListener = new Thread(new ThreadStart(RegisterListenerWork));
            tRegisterListener.Start();

            tLogInListener.Join();
            tRegisterListener.Join();
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void LogInListenerWork()
        {
            LogInListener listenLogIn = LogInListener.Instance;
            listenLogIn.Listener();
        }

        static void RegisterListenerWork()
        {
            RegisterListener listenRegister = RegisterListener.Instance;
            listenRegister.Listener();
        }
    }
}
