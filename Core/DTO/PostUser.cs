using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class PostUser
    {
        public int id { get; set; }
        public DateTime? createdate { get; set; }
        public char? state { get; set; }
        public string desc_ { get; set; }
        public char? postion { get; set; }
        public string username { get; set; }
    }
}
