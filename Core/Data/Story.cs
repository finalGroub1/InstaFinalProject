using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
   public class Story
    {
        [Key]
        public int id { get; set; }
        public DateTime createdate { get; set; }
        public int user_id { get; set; }
        public string? descrption { get; set; }
        public int? state { get; set; }
        public string imagePath { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }

        public ICollection<Interaction> Interactions { get; set; }
        public ICollection<MediaPost> MediaPosts { get; set; }
    }
}
