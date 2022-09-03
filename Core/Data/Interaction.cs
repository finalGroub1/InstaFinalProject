using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class Interaction
    {
        [Key]
        public int id { get; set; }
        public string? intertype { get; set; }
        public int user_id { get; set; }
        public int? post_id { get; set; }
        public int? story_id { get; set; }
        public DateTime? datelike { get; set; }


        [ForeignKey("user_id")]
        public virtual User User { get; set; }


        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }


        [ForeignKey("story_id")]
        public virtual Story Story { get; set; }
    }
}
