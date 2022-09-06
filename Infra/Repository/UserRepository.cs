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
        private readonly IFollowersRepository _FollowersRepository;
        public UserRepository(IDBContext IDBContext, IFollowersRepository FollowersRepository)
        {
            _IDBContext = IDBContext;
            _FollowersRepository = FollowersRepository;
        }

        public bool deleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.deleteUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool createChickIn(string email)///////////////////////
        {  
            var emailuser = getallUser().ToList();
            var emailuser2 = emailuser.Where(x => x.email == email).FirstOrDefault();
            string timeInString = DateTime.Now.ToString("HH.mm");
            double timeDouble = Convert.ToDouble(timeInString);
            emailuser2.check_in = timeDouble;
            emailuser2.Date_of_spend = DateTime.Now;
            emailuser2.isactive = 1;
            updateUserLogin(emailuser2);
            return true;
        }
        public bool SpendTime(int id)
        {

            var user = getbyidUser(id);

            string timeNow = DateTime.Now.ToString("HH.mm");
            double timeDouble = Convert.ToDouble(timeNow);

            if (user.Date_of_spend.Day.ToString("MM:dd:YYYY") == DateTime.Now.Day.ToString("MM:dd:YYYY"))
            {
                user.spend_time += Math.Round((timeDouble - user.check_in), 2);
            }
            else
            {
                user.spend_time = Math.Round((timeDouble - user.check_in), 2);
            }

            //we will add a prop in database in datatype date and will take the value from here
            user.isactive = 0;
            updateUserLogin(user);
            return true;
        }
        public List<User> getTop10()
        {
            IEnumerable<User> result = _IDBContext.Connection.Query<User>("User_F_package.getallUser", commandType: CommandType.StoredProcedure);
            return result.Where(x=> x.Date_of_spend.Day == DateTime.Now.Day).OrderByDescending(x=> x.spend_time).Take(10).ToList();
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
           
            result.followerCount = _FollowersRepository.getalluserFollowing(id).Count();//الناس اللي متابعينك
            result.followingCount = _FollowersRepository.getalluserThatFollow(id).Count();//الناس الي متابعم
            return result;
        }

        public List<User> getbynameUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Uname", user.name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> result = _IDBContext.Connection.Query<User>("User_F_package.getbynameUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<User> getactiveUser()
        {
            IEnumerable<User> result = _IDBContext.Connection.Query<User>("User_F_package.getactiveuser", commandType: CommandType.StoredProcedure);
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
            p.Add("@pass", user.password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Rid", user.role_id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Upin", user.pin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ucheck_in", null, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Uspend_time", null, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Udate_of_spend", null, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            
            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.insertUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateUser(User user)
        {
            var userEdit = getbyidUser(user.id);
            if(user.imge == null)
            {
                user.imge = userEdit.imge;
            }
            var p = new DynamicParameters();
            p.Add("@Uid", user.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uname", user.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uphone", user.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uimg", user.imge, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uaddres", user.addres, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ugender", userEdit.gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uusername", userEdit.username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uemail", user.email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Uisblocked", userEdit.isblock, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uisactive", userEdit.isactive, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@pass", user.password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Rid", userEdit.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Upin", userEdit.pin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ucheck_in", user.check_in, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Uspend_time", user.spend_time, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Udate_of_spend", user.Date_of_spend, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            //add new prop datatype date
            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.updateUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool updateUserLogin(User user)
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
            p.Add("@pass", user.password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Rid", user.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Upin", user.pin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ucheck_in", user.check_in, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Uspend_time", user.spend_time, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Udate_of_spend", user.Date_of_spend, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            //add new prop datatype date
            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.updateUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool blockUser(int id)
        {
            var p2 = new DynamicParameters();
            p2.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var user = _IDBContext.Connection.Query<User>("User_F_package.getbyidUser", p2, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if (user.role_id == 3) {
                user.role_id = 2;
            
            }
            else if (user.role_id ==2)
            {
                user.role_id = 3;

            }
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
            p.Add("@pass", user.password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Rid", user.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Upin", user.pin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ucheck_in", user.check_in, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Uspend_time", user.spend_time, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Udate_of_spend", user.Date_of_spend, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            
            //add new prop datatype date

            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.updateUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public Int32 UserCount()
        {
            List<User> c = getallUser();

            return  c.Count;
        }
    }
}
