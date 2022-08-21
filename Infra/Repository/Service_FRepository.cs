using Core.Common;
using Core.Data;
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
            IEnumerable<Service_F> result = _IDBContext.Connection.Query<Service_F>("Service_F_package.getallService", commandType: CommandType.StoredProcedure);
            return result.ToList();
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
            p.Add("@des", service.desc, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@dIn", service.datein, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@dTo", service.dateto, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@P", service.price, dbType: DbType.Double, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Service_F_package.insertService", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateService(Service_F service)
        {
            var p = new DynamicParameters();
            p.Add("@idofService", service.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@des", service.desc, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@dIn", service.datein, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@dTo", service.dateto, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@P", service.price, dbType: DbType.Double, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Service_F_package.insertService", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
