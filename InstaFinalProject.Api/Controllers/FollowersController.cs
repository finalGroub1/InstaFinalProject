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
        [Route("delete/{id}/{idup}")]
        public bool deleteFollowers(int id, int idup)
        {
            return followersService.deleteFollowers(id, idup);
        }

        [HttpGet]
        public List<Followers> getallFollowers()
        {
            return followersService.getallFollowers();
        }
        [HttpGet]
        [Route("getfollower/{userid}")]
        public List<User> getalluserToFollow(int userid)
        {
            return followersService.getalluserToFollow(userid);
        }
        [HttpGet]
        [Route("getfollowthat/{userid}")]
        public List<User> getalluserThatFollow(int userid)
        {
            return followersService.getalluserThatFollow(userid);
        }
        [HttpGet]
        [Route("getfollowing/{userid}")]
        public List<User> getalluserFollowing(int userid) 
        {
            return followersService.getalluserFollowing(userid);
        }

        [HttpGet]
        [Route("GetById")]
        public Followers getbyidFollowers(int id)
        {
            return followersService.getbyidFollowers(id);
        }

        [HttpPost]
        public bool insertFollowers([FromBody] Followers followers)
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
