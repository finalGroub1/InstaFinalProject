using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
   public class Login
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string pin_random { get; set; }

        public int role_id { get; set; }
        [ForeignKey("role_id")]
        public virtual Role Role { get; set; }

        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual User User { get; set; }

    }
}
