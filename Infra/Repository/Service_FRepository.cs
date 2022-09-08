using Core.Common;
using Core.Data;
using Core.DTO;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class Service_FRepository : IService_FRepository
    {
        private readonly IDBContext _IDBContext;

        public Service_FRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteService(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofService", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Service_F_package.deleteService", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Service_F> getallService()
        {
            IEnumerable<Service_F> service = _IDBContext.Connection.Query<Service_F>("Service_F_package.getallService", commandType: CommandType.StoredProcedure);
            var serviceUser = _IDBContext.Connection.Query<ServiceUser>("ServiceUser_package.getallServiceUser", commandType: CommandType.StoredProcedure).ToList();

            foreach (var item in service)
            {
                var countOfServiceUser = serviceUser.Where(x => x.service_id == item.id).ToList();
                if (countOfServiceUser.Count != 0)
                {
                    item.countOfUsers = 1;
                }
                else
                {
                    item.countOfUsers = 0;
                }
            } 
            return service.ToList();
        }

        public Service_F getbyidService(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofService", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Service_F>("Service_F_package.getbyidService", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertService(Service_F service)
        {
            var p = new DynamicParameters();
            p.Add("@Sduration", service.duration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@P", service.price, dbType: DbType.Double, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Service_F_package.insertService", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateService(Service_F service)
        {
            var p = new DynamicParameters();
            p.Add("@idofService", service.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Sduration", service.duration, dbType: DbType.Int32, direction: ParameterDirection.Input);    
            p.Add("@P", service.price, dbType: DbType.Double, direction: ParameterDirection.Input);


            var result = _IDBContext.Connection.ExecuteAsync("Service_F_package.updateService", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<serviceuser_dto> serviceuser()
        {
            IEnumerable<serviceuser_dto> result = _IDBContext.Connection.Query<serviceuser_dto>("Service_F_package.serviceuser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
