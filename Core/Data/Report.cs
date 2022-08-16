using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
   public class Report
    {
        [Key]
        public int id { get; set; }
        public string desc_ { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }


        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }

    }
}
