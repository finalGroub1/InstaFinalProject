using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface ILoginRepository
    {
        public List<Login> getallLogin();

        public bool updateLogin(Login login);

        public bool deleteLogin(int id);

        public bool insertLogin(Login login);

        public Login getbyidLogin(int id);

        //JWT
        Login Auth(Login login);

    }
}
