using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool blockUser(int id)
        {
            return userRepository.blockUser(id);
        }
        public bool ForgetPassword(string email)
        {
            return userRepository.ForgetPassword(email);
        }

        public bool deleteUser(int id)
        {
            return userRepository.deleteUser(id);
        }
        public bool createChickIn(string email)
        {
            return userRepository.createChickIn(email);
        }
        public bool SpendTime(int id)
        {
            return userRepository.SpendTime(id);
        }
        public List<User> getTop10()
        {
            return userRepository.getTop10();
        }

        public List<User> getactiveUser()
        {
            return userRepository.getactiveUser();
        }

        public List<User> getallUser()
        {
            return userRepository.getallUser();
        }

        public User getbyidUser(int id)
        {
            return userRepository.getbyidUser(id);
        }

        public List<User> getbynameUser(User user)
        {
            return userRepository.getbynameUser(user);
        }

        public bool insertUser(User user)
        {
            return userRepository.insertUser(user);
        }

        public bool updateUser(User user)
        {
            return userRepository.updateUser(user);
        }
        public Int32 UserCount()
        {
            return userRepository.UserCount();
        }
    }
}
