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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDBContext _IDBContext;

        public RoleRepository(IDBContext IDBContext)
        {
            _IDBContext = IDBContext;
        }

        public bool deleteRole(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofRole", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _IDBContext.Connection.Execute("Role_package.deleteRole", parameter, commandType: CommandType.StoredProcedure);
            return true;

        }

        public List<Role> getallRole()
        {
            var result = _IDBContext.Connection.Query<Role>("Role_package.getallRole", commandType: CommandType.StoredProcedure).ToList();
            return result;

          
        }

        public Role getbyidRole(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofRole", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Role>("Role_package.getbyidRole", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;

        }

        public bool insertRole(Role role)
        {
            var parameter = new DynamicParameters();
            parameter.Add("rolename", role.name, dbType: DbType.String, direction: ParameterDirection.Input);

            _IDBContext.Connection.ExecuteAsync("Role_package.insertRole", parameter, commandType: CommandType.StoredProcedure);

            return true;


        }

        public bool updateRole(Role role)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofRole", role.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("rolename", role.name, dbType: DbType.String, direction: ParameterDirection.Input);

            _IDBContext.Connection.ExecuteAsync("Role_package.updateRole", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
