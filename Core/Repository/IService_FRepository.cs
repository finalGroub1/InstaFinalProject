using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface IService_FRepository
    {
        public List<Service_F> getallService();

        public bool updateService(Service_F service);

        public bool deleteService(int id);

        public bool insertService(Service_F service);
        public List<serviceuser_dto> serviceuser();

        public Service_F getbyidService(int id);
    }
}
