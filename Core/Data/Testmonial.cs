using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
   public class Testmonial
    {
        [Key]
        public int id { get; set; }
        public int state { get; set; }
        public string description { get; set; }
        public int evaluation { get; set; }


        // must be added relation with table user to know who the user is submitted this testemonial


        //public int userid { get; set; }
        //[ForeignKey("userid")]
        //public virtual User user { get; set; }


    }
}
