using Core.Common;
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
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IDBContext dBContext;
        public AuthenticationRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public Login_dto auth(Login_dto login)
        {

            var parameter = new DynamicParameters();
            parameter.Add("email1", login.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("password1", login.password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Login_dto> result = dBContext.Connection.Query<Login_dto>("Login_package.Auth", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
