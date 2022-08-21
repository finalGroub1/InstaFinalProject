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
    public class ServiceController : Controller
    {
        private readonly IService_FService service_FService;

        public ServiceController(IService_FService service_FService)
        {
            this.service_FService = service_FService;
        }
        
        [HttpDelete]
        public bool deleteService(int id)
        {
            return service_FService.deleteService(id);
        }

        [HttpGet]
        public List<Service_F> getallService()
        {
            return service_FService.getallService();
        }

        [HttpGet]
        [Route("GetById")]
        public Service_F getbyidService(int id)
        {
            return service_FService.getbyidService(id);
        }

        [HttpPost]
        public bool insertService(Service_F service)
        {
            return service_FService.insertService(service);
        }

        [HttpPut]
        public bool updateService(Service_F service)
        {
            return service_FService.updateService(service);
        }
    }
}
