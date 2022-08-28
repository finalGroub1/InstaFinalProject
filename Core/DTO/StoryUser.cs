using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class StoryUser
    {
        public int id { get; set; }
        public DateTime? createdate { get; set; }
        public string descrption { get; set; }
        public int user_id { get; set; }
        public int? state { get; set; }
        public string name { get; set; }
    }
}
