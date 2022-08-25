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
    public class LoginRepository : ILoginRepository
    {
        private readonly IDBContext _IDBContext;

        public LoginRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Lid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Login_package.deleteLogin", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Login> getallLogin()
        {
            IEnumerable<Login> result = _IDBContext.Connection.Query<Login>("Login_package.getallLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Login getbyidLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Lid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Login>("Login_package.getbyidLogin", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Lemail", login.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lpass",login.pass, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lpin_random", login.pin_random, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lrole_id", login.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Luser_id", login.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Login_package.insertLogin", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Lid", login.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Lemail", login.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lpass", login.pass, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lpin_random", login.pin_random, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lrole_id", login.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Luser_id", login.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Login_package.updateLogin", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //JWT
        public Login Auth(Login login)
        {
            var p = new DynamicParameters();
            p.Add("@Lemail", login.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Lpass", login.pass, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Login> result = _IDBContext.Connection.Query<Login>("User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
