using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
   public class Visa
    {
        [Key]
        public int id { get; set; }
        public string number_ { get; set; }
        public string name_ { get; set; }
        public int cvv { get; set; }
        public int mm { get; set; }
        public int yy { get; set; }
        public int user_id { get; set; }
        public double amount { get; set; }
        [NotMapped]
        public int postId { get; set; }
        [NotMapped]
        public int ServiceId { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }

    }
}
