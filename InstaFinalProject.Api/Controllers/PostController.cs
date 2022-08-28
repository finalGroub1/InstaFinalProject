using Core.Data;
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
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        //..

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deletePost(int id)
        {
            return postService.deletePost(id);
        }

        [HttpGet]
        public List<Post> getallPost()
        {
            return postService.getallPost();
        }

        [HttpGet]
        [Route("GetPostUser")]
        public List<PostUser> getallPostUser()
        {
            return postService.getallPostUser();
        }

        [HttpGet]
        [Route("GetById")]
        public Post getbyidPost(int id)
        {
            return postService.getbyidPost(id);
        }

        [HttpPost]
        public bool insertPost([FromBody] Post post)
        {
            return postService.insertPost(post);
        }

        [HttpPut]
        public bool updatePost(Post post)
        {
            return postService.updatePost(post);
        }
    }
}
