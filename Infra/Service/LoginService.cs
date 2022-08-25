using Core.Data;
using Core.Repository;
using Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        //JWT
        public string Auth(Login login)
        {
            var result = loginRepository.Auth(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("[Mutaz key -this should be more longer]");
                var tokenDiscriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                          new Claim(ClaimTypes.Name,result.email),
                          new Claim(ClaimTypes.Role,result.Role.name),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDiscriptor);

                return tokenHandler.WriteToken(token);
            }
        }

    }
}
