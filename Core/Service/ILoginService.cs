using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface ILoginService
    {
        public List<Login> getallLogin();

        public bool updateLogin(Login login);

        public bool deleteLogin(int id);

        public bool insertLogin(Login login);

        public Login getbyidLogin(int id);

    }
}
