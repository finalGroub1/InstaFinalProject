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
    public class ServiceUserController : Controller
    {
        private readonly IServiceUserService serviceUserService;

        public ServiceUserController(IServiceUserService serviceUserService)
        {
            this.serviceUserService = serviceUserService;
        }

        [HttpDelete]
        public bool deleteServiceUser(int id)
        {
            return serviceUserService.deleteServiceUser(id);
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

        [HttpPost]
        public bool insertServiceUser(ServiceUser serviceUser)
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
