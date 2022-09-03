using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class AdminReportDto
    {
        public List<Report> report { get; set; }
        public Post post { get; set; }
        public int ReportCount { get; set; }
    }
}
