using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class ServiceUserService : IServiceUserService
    {
        private readonly IServiceUserRepository serviceUserRepository;

        public ServiceUserService(IServiceUserRepository serviceUserRepository)
        {
            this.serviceUserRepository = serviceUserRepository;
        }

        public bool deleteServiceUser(int id)
        {
            return serviceUserRepository.deleteServiceUser(id);
        }

        public List<ServiceUser> getallServiceUser()
        {
            return serviceUserRepository.getallServiceUser();
        }

        public ServiceUser getbyidServiceUser(int id)
        {
            return serviceUserRepository.getbyidServiceUser(id);
        }

        public bool insertServiceUser(ServiceUser serviceUser)
        {
            return serviceUserRepository.insertServiceUser(serviceUser);
        }

        public bool updateServiceUser(ServiceUser serviceUser)
        {
            return serviceUserRepository.updateServiceUser(serviceUser);
        }
    }
}
