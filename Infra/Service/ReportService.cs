using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public bool deleteReport(int id)
        {
            return reportRepository.deleteReport(id);
        }

        public List<Report> getallReport()
        {
            return reportRepository.getallReport();
        }

        public Report getbyidReport(int id)
        {
            return reportRepository.getbyidReport(id);
        }

        public bool insertReport(Report report)
        {
            return reportRepository.insertReport(report);
        }

        public bool updateReport(Report report)
        {
            return reportRepository.updateReport(report);
        }
    }
}
