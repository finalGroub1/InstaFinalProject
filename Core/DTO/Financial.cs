using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class Financial
    {
        public double monthlyProfit { get; set; }
        public double annualProfit { get; set; }
        public int userActive { get; set; }
        public int numberOfService { get; set; }
        public int numberOfOrders { get; set; }
    }
}
