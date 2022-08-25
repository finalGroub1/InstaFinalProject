using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IAuthenticationRepository
    {
        public Login_dto auth(Login_dto login);
    }
}
