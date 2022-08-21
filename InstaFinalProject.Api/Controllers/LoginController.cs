using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpDelete]
        public bool deleteLogin(int id)
        {
            return loginService.deleteLogin(id);
        }

        [HttpGet]
        public List<Login> getallLogin()
        {
            return loginService.getallLogin();
        }

        [HttpGet]
        [Route("GetById")]
        public Login getbyidLogin(int id)
        {
            return loginService.getbyidLogin(id);
        }

        [HttpPost]
        public bool insertLogin(Login login)
        {
            return loginService.insertLogin(login);
        }

        [HttpPut]
        public bool updateLogin(Login login)
        {
            return loginService.updateLogin(login);
        }
    }
}
