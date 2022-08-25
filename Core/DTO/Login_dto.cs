using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class Login_dto
    {
        public int id { get; set; }
        public string rolename { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
