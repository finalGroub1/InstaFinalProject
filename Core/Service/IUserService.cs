using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IUserService
    {
        public List<User> getallUser();

        public bool updateUser(User user);

        public bool deleteUser(int id);

        public bool insertUser(User user);

        public User getbyidUser(int id);

        public List<User> getbynameUser(User user);

    }
}
