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
    public class MessageController : Controller
    {
        private readonly ImessageService imessageService;

        public MessageController(ImessageService imessageService)
        {
            this.imessageService = imessageService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteMessage(int id)
        {
            return imessageService.deleteMessage(id);
        }

        [HttpGet]
        public List<Message> getallMessage()
        {
            return imessageService.getallMessage();
        }

        [HttpGet]
        [Route("GetById")]
        public Message getbyidMessage(int id)
        {
            return imessageService.getbyidMessage(id);
        }

        [HttpPost]
        public bool insertMessage([FromBody] Message message)
        {
            return imessageService.insertMessage(message);
        }

        [HttpPut]
        public bool updateMessage(Message message)
        {
            return imessageService.updateMessage(message);
        }
    }
}
