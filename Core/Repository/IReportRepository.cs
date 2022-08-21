using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
  public  interface IReportRepository
    {
        public List<Report> getallReport();

        public bool updateReport(Report report);

        public bool deleteReport(int id);

        public bool insertReport(Report report);

        public Report getbyidReport(int id);
    }
}
