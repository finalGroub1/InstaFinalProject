using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        public DateTime? createdate { get; set; }
        public char? state { get; set; }
        public string? desc_ { get; set; }
        public char? postion { get; set; }
        public int? user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }

        public ICollection<ServiceUser> Serviceusers { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
        public ICollection<Report> Reports { get; set; }
        public ICollection<MediaPost> MediaPosts { get; set; }

    }
}
