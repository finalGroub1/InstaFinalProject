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
            
            IEnumerable<User> allUser = _IDBContext.Connection.Query<User>("User_F_package.getallUser", commandType: CommandType.StoredProcedure).ToList();



    //////////////////////////////////////////////////////////////////////

            IEnumerable<Followers> result = _IDBContext.Connection.Query<Followers>("Followers_package.getallFollowers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<User> getalluserToFollow(int userid)// الناس اللي مو متابعهم
        {

            IEnumerable<User> allUserfollow = _IDBContext.Connection.Query<User>("User_F_package.getallUser", commandType: CommandType.StoredProcedure).ToList();
            
            
            var allfollowers = getallFollowers();
            var followUp = allfollowers.Where(i => i.user_id_up == userid ).ToList();            

             var followUpObject = allUserfollow.Where(x => followUp.Any(y => y.user_id_back.Equals(x.id)));
             var result = allUserfollow.Except(followUpObject).Where(x=> x.id != userid);            

            return result.ToList();
        }
        public List<User> getalluserFollowing(int userid) //الناس اللي متابعينك
        {

            IEnumerable<User> allUserfollow = _IDBContext.Connection.Query<User>("User_F_package.getallUser", commandType: CommandType.StoredProcedure).ToList();


            var allfollowers = getallFollowers();
            var followUp = allfollowers.Where(i => i.user_id_back == userid).ToList();
            

            var followUpObject = allUserfollow.Where(x => followUp.Any(y => y.user_id_up.Equals(x.id)));
            
            var result = followUpObject.Where(x => x.id != userid);

            return result.ToList();
        }
        public List<User> getalluserThatFollow(int userid) // الناس اللي متابعهم
        {

            IEnumerable<User> allUserfollow = _IDBContext.Connection.Query<User>("User_F_package.getallUser", commandType: CommandType.StoredProcedure).ToList();


            var allfollowers = getallFollowers();
            var followUp = allfollowers.Where(i => i.user_id_up == userid).ToList();            

            var followUpObject = allUserfollow.Where(x => followUp.Any(y => y.user_id_back.Equals(x.id)));

            var result = followUpObject.Where(x => x.id != userid);

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
