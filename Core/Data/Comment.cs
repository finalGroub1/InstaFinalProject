using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public string desc_ { get; set; }
        public DateTime? date_ { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public int? comment_reply_id { get; set; }


        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }

        [ForeignKey("comment_reply_id")]
        public virtual Comment Comments{ get; set; }

    }
}
