using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IServiceUserRepository
    {
        public List<ServiceUser> getallServiceUser();

        public bool updateServiceUser(ServiceUser serviceUser);

        public bool deleteServiceUser(int id);

        public bool insertServiceUser(ServiceUser serviceUser);

        public ServiceUser getbyidServiceUser(int id);
        public List<ServiceUser> getallMyserviceUser(int id);
        public Financial Financial();
        public double annualFinancial();
    }
}
