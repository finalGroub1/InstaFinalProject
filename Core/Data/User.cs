using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
  public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string imge { get; set; }
        public string addres { get; set; }
        public string gender { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int isblock { get; set; }
        public int isactive { get; set; }
        public string password { get; set; }
        [NotMapped]
        public int isfollowBack { get; set; }
        public string? pin { get; set; }
        public double check_in { get; set; }
        public double spend_time { get; set; }
        public DateTime Date_of_spend { get; set; }

        public int role_id { get; set; }
        [ForeignKey("role_id")]
        public virtual Role Role { get; set; }

        public ICollection<Login> Logins { get; set; }
        public ICollection<ServiceUser> Serviceusers { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Story> Stories { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Followers> Followers { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
        public ICollection<Report> Reports { get; set; }
        public ICollection<Visa> Visas { get; set; }

    }
}
