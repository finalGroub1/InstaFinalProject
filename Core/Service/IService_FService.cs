using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface IService_FService
    {
        public List<Service_F> getallService();

        public bool updateService(Service_F service);

        public bool deleteService(int id);

        public bool insertService(Service_F service);

        public Service_F getbyidService(int id);
        public List<serviceuser_dto> serviceuser();
    }
}
