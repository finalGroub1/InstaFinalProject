using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface IUserRepository
    {
        public List<User> getallUser();

        public bool updateUser(User user);

        public bool deleteUser(int id);

        public bool insertUser(User user);

        public User getbyidUser(int id);
    }
}
