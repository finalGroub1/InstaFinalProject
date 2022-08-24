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
    public class UserRepository : IUserRepository
    {
        private readonly IDBContext _IDBContext;

        public UserRepository(IDBContext IDBContext)
        {
            _IDBContext = IDBContext;
        }

        public bool deleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.deleteUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<User> getallUser()
        {
            IEnumerable<User> result = _IDBContext.Connection.Query<User>("User_F_package.getallUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public User getbyidUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<User>("User_F_package.getbyidUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public List<User> getbynameUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Uname", user.name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> result = _IDBContext.Connection.Query<User>("User_F_package.getbynameUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool insertUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Uname", user.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uphone", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uimg", user.imge, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uaddres", user.addres, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ugender", user.gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uusername", user.username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uemail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uisblocked", user.isblock, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uisactive", user.isactive, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.insertUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", user.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uname", user.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uphone", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uimg", user.imge, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uaddres", user.addres, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ugender", user.gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uusername", user.username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uemail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uisblocked", user.isblock, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uisactive", user.isactive, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.updateUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
