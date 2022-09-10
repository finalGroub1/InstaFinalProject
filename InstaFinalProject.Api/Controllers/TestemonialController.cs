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
    public class TestemonialController : Controller
    {
        private readonly ITestemonialService testemonialService;

        public TestemonialController(ITestemonialService testemonialService)
        {
            this.testemonialService = testemonialService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteTestemonial(int id)
        {
            return testemonialService.deleteTestemonial(id);
        }

        [HttpGet]
        public List<Testmonial> getallTestemonial()
        {
            return testemonialService.getallTestemonial();
        }

        [HttpGet]
        [Route("GetById")]
        public Testmonial getbyidTestemonial(int id)
        {
            return testemonialService.getbyidTestemonial(id);
        }

        [HttpPost]
        public bool insertTestemonial([FromBody] Testmonial testmonial)
        {
            return testemonialService.insertTestemonial(testmonial);
        }
        [HttpGet]
        [Route("ChangeState/{id}")]
        public bool ChangeState(int id)
        {
            return testemonialService.ChangeState(id);
        }

        [HttpPut]
        public bool updateTestemonial(Testmonial testmonial)
        {
            return testemonialService.updateTestemonial(testmonial);
        }
    }
}
