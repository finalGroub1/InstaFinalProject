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
        public bool createChickIn(string email)
        {
            var emailuser = getallUser().ToList();
            var emailuser2 = emailuser.Where(x => x.email == email).FirstOrDefault();
            emailuser2.check_in = DateTime.Now;
            updateUserLogin(emailuser2);
            return true;
        }

        public List<User> getallUser()
        {
            IEnumerable<User> result = _IDBContext.Connection.Query<User>("User_F_package.getallUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool SpendTime(int id)
        {
            DateTime d1 = DateTime.Now;
            string s1 = d1.ToString();
            d1 = Convert.ToDateTime(s1);

           string test= DateTime.Now.ToString("HH.mm");
           double oo= Convert.ToDouble(test);
            DateTime d2 = Convert.ToDateTime(test);
            var user = getbyidUser(id);

           
            //TimeSpan a = new TimeSpan(12, 00, 00);
            var time = Convert.ToDateTime(user.spend_time);
          
            var check = Convert.ToDateTime(user.check_in);
           
            updateUserLogin(user);
            return true;
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
            p.Add("@Ucheck_in", user.check_in, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uspend_time", user.spend_time, dbType: DbType.DateTime, direction: ParameterDirection.Input);

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
            p.Add("@Ucheck_in", userEdit.check_in, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uspend_time", userEdit.spend_time, dbType: DbType.DateTime, direction: ParameterDirection.Input);

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
            p.Add("@Ucheck_in", user.check_in, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uspend_time", user.spend_time, dbType: DbType.DateTime, direction: ParameterDirection.Input);

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
            p.Add("@Rid",user.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
