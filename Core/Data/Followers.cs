using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
   public class Followers
    {
        [Key]
        public int id { get; set; }

        public int user_id_up { get; set; }
        [ForeignKey("user_id_up")]
        public virtual User UserUp  { get; set; }

        public int user_id_back { get; set; }
        [ForeignKey("user_id_back")]
        public virtual User UserBack { get; set; }
        [NotMapped]
        public int isfollowBack { get; set; }

    }
}
