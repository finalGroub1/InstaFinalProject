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
    public class ReportController : Controller
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpDelete]
        public bool deleteReport(int id)
        {
            return reportService.deleteReport(id);
        }

        [HttpGet]
        public List<Report> getallReport()
        {
            return reportService.getallReport();
        }

        [HttpGet]
        [Route("GetById")]
        public Report getbyidReport(int id)
        {
            return reportService.getbyidReport(id);
        }

        [HttpPost]
        public bool insertReport(Report report)
        {
            return reportService.insertReport(report);
        }

        [HttpPut]
        public bool updateReport(Report report)
        {
            return reportService.updateReport(report);
        }
    }
}
