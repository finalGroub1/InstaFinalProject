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
    public class FollowersRepository : IFollowersRepository
    {
        private readonly IDBContext _IDBContext;

        public FollowersRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteFollowers(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofFollowers", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Followers_package.deleteFollowers", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Followers> getallFollowers()
        {
            IEnumerable<Followers> result = _IDBContext.Connection.Query<Followers>("Followers_package.getallFollowers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Followers getbyidFollowers(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofFollowers", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Followers>("Followers_package.getbyidFollowers", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertFollowers(Followers followers)
        {
            var p = new DynamicParameters();
            p.Add("@uUp", followers.user_id_up, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@uBack", followers.user_id_back, dbType: DbType.Int32, direction: ParameterDirection.Input);
          
            var result = _IDBContext.Connection.ExecuteAsync("Followers_package.insertFollowers", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateFollowers(Followers followers)
        {
            var p = new DynamicParameters();
            p.Add("@idofFollowers", followers.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@uUp", followers.user_id_up, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@uBack", followers.user_id_back, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Followers_package.updateFollowers", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
