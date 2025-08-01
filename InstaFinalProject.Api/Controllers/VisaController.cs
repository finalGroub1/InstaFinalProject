﻿using Core.Data;
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
    public class VisaController : Controller
    {
        private readonly IVisaService visaService;

        public VisaController(IVisaService visaService)
        {
            this.visaService = visaService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteVisa(int id)
        {
            return visaService.deleteVisa(id);
        }

        [HttpGet]
        [Route("getallVisa/{id}")]
        public List<Visa> getallVisa(int id)
        {
            return visaService.getallVisa(id);
        }

        [HttpGet]
        [Route("GetById")]
        public Visa getbyidVisa(int id)
        {
            return visaService.getbyidVisa(id);
        }
        [HttpPost]
        [Route("Chickvisa")]
        public bool Chickvisa(Visa visa)
        {
            return visaService.Chickvisa(visa);
        }

        [HttpPost]
        public bool insertVisa([FromBody] Visa visa)
        {
            return visaService.insertVisa(visa);
        }

        [HttpPut]
        public bool updateVisa(Visa visa)
        {
            return visaService.updateVisa(visa);
        }
    }
}
