using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProjServers
{
    class Output
    {
        private static Output instance = null;
        private static readonly object padlock = new object();
        public Form1 output = null;

        public static Output Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Output();
                    }

                    return instance;
                }

            }
        }

        public void setOutput(Form1 form)
        {
            output = form;
        }

        public void AppendMsg(string msg)
        {
            output.OutputMsg(msg);
        }
    }
}
