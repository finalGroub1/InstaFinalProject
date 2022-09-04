using Core.DTO;
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
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenticationService authenticationservice;
        private readonly IUserService _userService;

        public AuthenController(IAuthenticationService authenticationservice, IUserService userService)
        {
            this.authenticationservice = authenticationservice;
            this._userService = userService;
        }
        [HttpPost]
        public IActionResult authen([FromBody] Login_dto login)
        {
            var RESULT = authenticationservice.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                _userService.createChickIn(login.email);
                return Ok(RESULT); //200
            }
        }
    }
}
