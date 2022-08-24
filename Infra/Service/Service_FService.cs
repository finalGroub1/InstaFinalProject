using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class Service_FService : IService_FService
    {
        private readonly IService_FRepository service_FRepository;

        public Service_FService(IService_FRepository service_FRepository)
        {
            this.service_FRepository = service_FRepository;
        }

        public bool deleteService(int id)
        {
            return service_FRepository.deleteService(id);
        }

        public List<Service_F> getallService()
        {
            return service_FRepository.getallService();
        }

        public Service_F getbyidService(int id)
        {
            return service_FRepository.getbyidService(id);
        }

        public bool insertService(Service_F service)
        {
            return service_FRepository.insertService(service);
        }

        public List<serviceuser_dto> serviceuser()
        {
            return service_FRepository.serviceuser();
        }

        public bool updateService(Service_F service)
        {
            return service_FRepository.updateService(service);
        }
    }
}
