﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class Contactus
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string massege { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
    }
}
