using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IAuthenticationService
    {
        public string Authentication_jwt(Login_dto login);
    }
}
