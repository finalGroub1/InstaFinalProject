using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class PostUser
    {
        public int id { get; set; }
        public DateTime? createdate { get; set; }
        public int? state { get; set; }
        public string desc_ { get; set; }
        public int? postion { get; set; }
        public string username { get; set; }
    }
}
