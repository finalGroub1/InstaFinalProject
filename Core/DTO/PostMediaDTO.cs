using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
   public class PostMediaDTO
    {
        public int id { get; set; }
        public DateTime createdate { get; set; }
        public int state { get; set; }
        public string description { get; set; }
        public int position { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string mediapath { get; set; }
    }
}
