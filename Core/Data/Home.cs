using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
   public class Home
    {
        [Key]
        public int id { get; set; }
        public string description1 { get; set; }
        public string description2 { get; set; }
        public string imge1 { get; set; }
        public string imge2 { get; set; }
    }
}
