using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class Message
    {
        [Key]
        public int id { get; set; }

        public string textme { get; set; }

        public DateTime timeme { get; set; }

        public int user_id_send { get; set; }
        [ForeignKey("user_id_send")]
        public virtual User UserSend { get; set; }

        public int user_id_res { get; set; }
        [ForeignKey("user_id_res")]
        public virtual User UserRes { get; set; }
    }
}
