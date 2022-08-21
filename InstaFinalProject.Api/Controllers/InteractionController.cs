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
    public class InteractionController : Controller
    {
        private readonly IInteractionService interactionService;

        public InteractionController(IInteractionService interactionService)
        {
            this.interactionService = interactionService;
        }

        [HttpDelete]
        public bool deleteInterAction(int id)
        {
            return interactionService.deleteInterAction(id);
        }

        [HttpGet]
        public List<Interaction> getallInterAction()
        {
            return interactionService.getallInterAction();
        }

        [HttpGet]
        [Route("GetById")]
        public Interaction getbyidInterAction(int id)
        {
            return interactionService.getbyidInterAction(id);
        }

        [HttpPost]
        public bool insertInterAction(Interaction Interaction)
        {
            return interactionService.insertInterAction(Interaction);
        }

        [HttpPut]
        public bool updateInterAction(Interaction Interaction)
        {
            return interactionService.updateInterAction(Interaction);
        }
    }
}
