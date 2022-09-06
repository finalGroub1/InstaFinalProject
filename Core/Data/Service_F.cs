using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class Service_F
    {
        [Key]
        public int id { get; set; }
        public int duration{ get; set; }
        public int price { get; set; }
    }
}
