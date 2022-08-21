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
    public class CommentController : Controller
    {
        private readonly ICommentService commentservice;

        public CommentController(ICommentService commentservice)
        {
            this.commentservice = commentservice;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteComment(int id)
        {
            return commentservice.deleteComment(id);
        }

        [HttpGet]
        public List<Comment> getallComment()
        {
            return commentservice.getallComment();
        }

        [HttpGet]
        [Route("GetById")]
        public Comment getbyidComment(int id)
        {
            return commentservice.getbyidComment(id);
        }

        [HttpPost]
        public bool insertComment([FromBody] Comment comment)
        {
            return commentservice.insertComment(comment);
        }

        [HttpPut]
        public bool updateComment(Comment comment)
        {
            return commentservice.updateComment(comment);
        }
    }
}
