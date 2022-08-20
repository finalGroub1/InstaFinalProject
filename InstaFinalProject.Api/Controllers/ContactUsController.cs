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
    public class ContactUsController : Controller
    {
        private readonly IContactUsService contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            this.contactUsService = contactUsService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteContact(int id)
        {
            return contactUsService.deleteContact(id);
        }

        [HttpGet]
        public List<Contactus> getallContact()
        {
            return contactUsService.getallContact();
        }

        [HttpGet]
        [Route("GetById")]
        public Contactus getbyidContact(int id)
        {
            return contactUsService.getbyidContact(id);
        }

        [HttpPost]
        public bool insertContact(Contactus contactus)
        {
            return contactUsService.insertContact(contactus);
        }

        [HttpPut]
        public bool updateContact(Contactus contactus)
        {
            return contactUsService.updateContact(contactus);
        }
    }
}
