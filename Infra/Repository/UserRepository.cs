﻿using Core.Common;
using Core.Data;
using Core.Repository;
using Dapper;
using MailKit.Net.Smtp;
using MimeKit;
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
               user.spend_time += Math.Abs(Math.Round((timeDouble - user.check_in), 2));
            }
            else
            {
                user.spend_time = Math.Abs(Math.Round((timeDouble - user.check_in), 2));
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
        //Email
        //to rest pass use email
        public bool ForgetPassword(string email)
            {
            var allUsers = getallUser();
            var user = allUsers.Where(x => x.email == email).FirstOrDefault();
            if(user != null)
            {
                MimeMessage message = new MimeMessage();
                BodyBuilder B = new BodyBuilder();
                MailboxAddress From = new MailboxAddress("Privacy  Instagram", "Privacyininstagram@hotmail.com");
                MailboxAddress to = new MailboxAddress("user", "finalGroub1@gmail.com");
                //----------------------------------------------------------------------------------
                B.HtmlBody = "<h1>Just <a href=\"http://localhost:4200/getpassword/" + user.id + "/" + user.pin + "\" >Click Her</a> to Redirect to rest pass page </h1>";
                message.Body = B.ToMessageBody();
                message.From.Add(From);
                message.To.Add(to);
                message.Subject = "Dear " + user.name + "";
                using (var item = new SmtpClient())
                {
                    item.Connect("smtp.office365.com", 587, false);
                    item.Authenticate("Privacyininstagram@hotmail.com", "Privacy#in@instagram#");
                    item.Send(message);
                    item.Disconnect(true);
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool checkPin(int id,string pin)
        {
            var user = getbyidUser(id);
            if(user.id==id&& user.pin==pin )
            {
                return true;
            }
            else
            {
                return false;
            }
        }  //مشان اشيك عليك

        public bool updateUserChangePin(User userpar)  //لما يخلص تعيين الباسورد الجديدة 
        {
            var user = getbyidUser(userpar.id);
            Random r = new Random();
            string r1 = Convert.ToString(r.Next(1000, 9999));
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
            p.Add("@pass", userpar.password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Rid", user.role_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Upin", r1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ucheck_in", user.check_in, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Uspend_time", user.spend_time, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
            p.Add("@Udate_of_spend", user.Date_of_spend, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            //add new prop datatype date
            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.updateUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        //---------------------
        public List<User> getbynameUser(User user)
        {
            var p = new DynamicParameters();
            p.Add("@Uname", user.name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> result = _IDBContext.Connection.Query<User>("User_F_package.getbynameUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<User> getbynameFollowing(User user)
        {
            if (user.name == "")
            {
                return _FollowersRepository.getalluserToFollow(user.id);
            }
            else
            {
                var followingFilter = _FollowersRepository.getalluserToFollow(user.id).Where(x => x.name.ToUpper().Contains(user.name.ToUpper())).ToList();
                return followingFilter;
            }
        }

        public List<User> getactiveUser()
        {
            IEnumerable<User> result = _IDBContext.Connection.Query<User>("User_F_package.getactiveuser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool insertUser(User user)
        {
            var userTest = getallUser().Where(x=> x.email == user.email).FirstOrDefault();
            var usernameTest = getallUser().Where(x => x.username == user.username).FirstOrDefault();
            if (userTest == null && usernameTest == null)
            {
                Random r = new Random();
                string r1 = Convert.ToString(r.Next(1000, 9999));
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
                p.Add("@Upin", r1, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("@Ucheck_in", null, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
                p.Add("@Uspend_time", null, dbType: DbType.Double, direction: ParameterDirection.Input);//edit
                p.Add("@Udate_of_spend", null, dbType: DbType.DateTime, direction: ParameterDirection.Input);

                var result = _IDBContext.Connection.ExecuteAsync("User_F_package.insertUser", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            return false;
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
