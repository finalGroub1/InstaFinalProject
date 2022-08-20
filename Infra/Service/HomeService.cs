using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            this.homeRepository = homeRepository;
        }

        public bool deleteHome(int id)
        {
            return homeRepository.deleteHome(id);
        }

        public List<Home> getallHome()
        {
            return homeRepository.getallHome();
        }

        public Home getbyidHome(int id)
        {
            return homeRepository.getbyidHome(id);
        }

        public bool insertHome(Home home)
        {
            return homeRepository.insertHome(home);
        }

        public bool updateHome(Home home)
        {
            return homeRepository.updateHome(home);
        }
    }
}
