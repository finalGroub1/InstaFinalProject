using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
  public class MediaPost
    {
        [Key]
        public int id { get; set; }
        public string mediapath { get; set; }
        public int post_id { get; set; }
        public int story_id { get; set; }
        [NotMapped]
        public int isVideo { get; set; }

        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }

        [ForeignKey("story_id")]
        public virtual Story Story { get; set; }
    }
}
