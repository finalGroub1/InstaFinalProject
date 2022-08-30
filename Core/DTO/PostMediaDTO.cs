using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
   public class PostMediaDTO
    {
        public int id { get; set; }
        public DateTime? createdate { get; set; }
        public int state { get; set; }
        public string? desc_ { get; set; }
        public int postion { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public List<string> mediapath { get; set; }
        public int post_id { get; set; }

    }
}
