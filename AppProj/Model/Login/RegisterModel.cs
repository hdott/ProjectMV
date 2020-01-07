using AppProj.Clients;
using AppProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProj.Model.Login
{
    class RegisterModel
    {
        public void RegisterProcess(UserData data)
        {
            byte[] _data = data.Serialize();

            RegisterClient.Instance.Register(_data);
        }
    }
}
