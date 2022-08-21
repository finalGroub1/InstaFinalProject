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
    public class FollowersController : Controller
    {
        private readonly IFollowersService followersService;

        public FollowersController(IFollowersService followersService)
        {
            this.followersService = followersService;
        }

        [HttpDelete]
        public bool deleteFollowers(int id)
        {
            return followersService.deleteFollowers(id);
        }

        [HttpGet]
        public List<Followers> getallFollowers()
        {
            return followersService.getallFollowers();
        }

        [HttpGet]
        [Route("GetById")]
        public Followers getbyidFollowers(int id)
        {
            return followersService.getbyidFollowers(id);
        }

        [HttpPost]
        public bool insertFollowers(Followers followers)
        {
            return followersService.insertFollowers(followers);
        }

        [HttpPut]
        public bool updateFollowers(Followers followers)
        {
            return followersService.updateFollowers(followers);
        }
    }
}
