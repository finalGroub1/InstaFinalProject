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
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpDelete]
        public bool deleteHome(int id)
        {
            return homeService.deleteHome(id);
        }

        [HttpGet]
        public List<Home> getallHome()
        {
            return homeService.getallHome();
        }

        [HttpGet]
        [Route("GetById")]
        public Home getbyidHome(int id)
        {
            return homeService.getbyidHome(id);
        }

        [HttpPost]
        public bool insertHome(Home home)
        {
            return homeService.insertHome(home);
        }

        [HttpPut]
        public bool updateHome(Home home)
        {
            return homeService.updateHome(home);
        }
    }
}
