using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface IFollowersRepository
    {
        public List<Followers> getallFollowers();

        public bool updateFollowers(Followers followers);

        public bool deleteFollowers(int id, int idup);

        public bool insertFollowers(Followers followers);

        public Followers getbyidFollowers(int id);
        public List<User> getalluserToFollow(int userid);
        public List<User> getalluserFollowing(int userid);
        public List<User> getalluserThatFollow(int userid);
    }
}
