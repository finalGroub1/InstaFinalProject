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
    public class UserController : Controller
    {
        private readonly IUserService UserService;

        public UserController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteUser(int id)
        {
            return UserService.deleteUser(id);
        }

        [HttpGet]
        public List<User> getallUser()
        {
            return UserService.getallUser();
        }

        [HttpGet("{id}")]
        public User getbyidUser(int id)
        {
            return UserService.getbyidUser(id);
        }

        [HttpPost]
        public bool insertUser([FromBody] User User)
        {
            return UserService.insertUser(User);
        }

        [HttpPut]
        public bool updateUser(User User)
        {
            return UserService.updateUser(User);
        }

    }
}
