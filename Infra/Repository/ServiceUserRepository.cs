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
    public class ServiceUserRepository : IServiceUserRepository
    {
        private readonly IDBContext _IDBContext;

        public ServiceUserRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteServiceUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofServiceUser", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("ServiceUser_package.deleteServiceUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ServiceUser> getallServiceUser()
        {
            IEnumerable<ServiceUser> result = _IDBContext.Connection.Query<ServiceUser>("ServiceUser_package.getallServiceUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ServiceUser getbyidServiceUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofServiceUser", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<ServiceUser>("ServiceUser_package.getbyidServiceUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertServiceUser(ServiceUser serviceUser)
        {
            var p = new DynamicParameters();
            p.Add("@Servid",serviceUser.service_id , dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid",serviceUser.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pid",serviceUser.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@dIn", serviceUser.datein, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@dTo", serviceUser.date_to, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("ServiceUser_package.insertServiceUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateServiceUser(ServiceUser serviceUser)
        {
            var p = new DynamicParameters();
            p.Add("@idofServiceUser", serviceUser.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Servid", serviceUser.service_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid", serviceUser.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pid", serviceUser.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@dIn", serviceUser.datein, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@dTo", serviceUser.date_to, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("ServiceUser_package.updateServiceUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
