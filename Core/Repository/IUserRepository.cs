﻿using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface IUserRepository
    {
        public List<User> getallUser();

        public List<User> getactiveUser();

        public bool updateUser(User user);

        public bool deleteUser(int id);
        public bool SpendTime(int id);

        public bool insertUser(User user);

        public User getbyidUser(int id);

        public bool blockUser(int id);
        public List<User> getTop10();
        public bool ForgetPassword(string email);
        public bool checkPin(int id, string pin);
        public bool updateUserChangePin(User userpar);

        public List<User> getbynameUser(User user);
        public List<User> getbynameFollowing(User user);
        public Int32 UserCount();
        public bool createChickIn(string email);

    }
}
