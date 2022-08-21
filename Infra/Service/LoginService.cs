using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public bool deleteLogin(int id)
        {
            return loginRepository.deleteLogin(id);
        }

        public List<Login> getallLogin()
        {
            return loginRepository.getallLogin();
        }

        public Login getbyidLogin(int id)
        {
            return loginRepository.getbyidLogin(id);
        }

        public bool insertLogin(Login login)
        {
            return loginRepository.insertLogin(login);
        }

        public bool updateLogin(Login login)
        {
            return loginRepository.updateLogin(login);
        }
    }
}
