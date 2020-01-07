using AppProj.Clients;
using AppProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProj.Model.Login
{
    public class LogInModel
    {
        //public LogInData Data { get; set; }

        public bool LogInProcess(LogInData data)
        {
            byte[] _data = data.Serialize();
            //Data = data;

            return LogInClient.Instance.LogIn(_data);
        }
    }
}
