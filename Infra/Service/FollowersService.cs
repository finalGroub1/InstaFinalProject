using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class FollowersService : IFollowersService
    {
        private readonly IFollowersRepository followersRepository;

        public FollowersService(IFollowersRepository followersRepository)
        {
            this.followersRepository = followersRepository;
        }

        public bool deleteFollowers(int id)
        {
            return followersRepository.deleteFollowers(id);
        }

        public List<Followers> getallFollowers()
        {
            return followersRepository.getallFollowers();
        }

        public Followers getbyidFollowers(int id)
        {
            return followersRepository.getbyidFollowers(id);
        }

        public bool insertFollowers(Followers followers)
        {
            return followersRepository.insertFollowers(followers);
        }

        public bool updateFollowers(Followers followers)
        {
            return followersRepository.updateFollowers(followers);
        }
    }
}
