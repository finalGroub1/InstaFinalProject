using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class StoryUser
    {
        public int id { get; set; }
        public DateTime? createdate { get; set; }
        public string description { get; set; }
        public int? state { get; set; }
        public string name { get; set; }
    }
}
