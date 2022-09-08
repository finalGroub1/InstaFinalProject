using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
   public class ServiceUser
    {
        [Key]
        public int id { get; set; }
        public int service_id { get; set; }
        public int user_id { get; set; }
        public int post_id { get; set; }

        public DateTime datein { get; set; }
        public DateTime date_to { get; set; }
        [NotMapped]
        public int NumberOfOrder { get; set; }
        [NotMapped]
        public int NumberOfServices { get; set; }
        [NotMapped]
        public double SumOfSales { get; set; }

        [ForeignKey("service_id")]
        public virtual Service_F Service_ { get; set; }

        [ForeignKey("user_id")]
        public virtual User User { get; set; }

        [ForeignKey("post_id")]
        public virtual Post Post { get; set; }

      

    }
}
