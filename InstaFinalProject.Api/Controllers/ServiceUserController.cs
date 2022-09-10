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
    public class ServiceUserController : Controller
    {
        private readonly IServiceUserService serviceUserService;

        public ServiceUserController(IServiceUserService serviceUserService)
        {
            this.serviceUserService = serviceUserService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteServiceUser(int id)
        {
            return serviceUserService.deleteServiceUser(id);
        }
        [HttpGet]
        [Route("Financial")]
        public Financial Financial()
        {
            return serviceUserService.Financial();
        }
        [HttpGet]
        [Route("annualFinancial")]
        public double annualFinancial()
        {
            return serviceUserService.annualFinancial();
        }

        [HttpGet]
        public List<ServiceUser> getallServiceUser()
        {
            return serviceUserService.getallServiceUser();
        }

        [HttpGet]
        [Route("GetById")]
        public ServiceUser getbyidServiceUser(int id)
        {
            return serviceUserService.getbyidServiceUser(id);
        }
        [HttpGet]
        [Route("getallMyserviceUser/{id}")]
        public List<ServiceUser> getallMyserviceUser(int id)
        {
            return serviceUserService.getallMyserviceUser(id);
        }

        [HttpPost]
        public bool insertServiceUser([FromBody] ServiceUser serviceUser)
        {
            return serviceUserService.insertServiceUser(serviceUser);
        }

        [HttpPut]
        public bool updateServiceUser(ServiceUser serviceUser)
        {
            return serviceUserService.updateServiceUser(serviceUser);
        }
    }
}
