using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InstaFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService UserService;

        public UserController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteUser(int id)
        {
            return UserService.deleteUser(id);
        }

        [HttpGet]
        public List<User> getallUser()
        {
            return UserService.getallUser();
        }

        [HttpGet]
        [Route("{id}")]
        public User getbyidUser(int id)
        {
            return UserService.getbyidUser(id);
        }
        [HttpPost]
        public bool insertUser([FromBody] User User)
        {
            return UserService.insertUser(User);
        }
        //gdfgfdgdfgd

        [HttpPost]
        [Route("GetByName")]
        public List<User> getbynameUser([FromBody] User user)
        {
            return UserService.getbynameUser(user);
        }

        [HttpPut]
        public bool updateUser(User User)
        {
            return UserService.updateUser(User);
        }

        [HttpGet]
        [Route("block/{id}")]
        public bool blockUser(int id)
        {
            return UserService.blockUser(id);
        }

        [HttpGet]
        [Route("Count")]
        public Int32 UserCount()
        {
            return UserService.UserCount();
        }

        [HttpGet]
        [Route("getActive")]
        public List<User> getactiveUser()
        {
            return UserService.getactiveUser();
        }
        [HttpGet]
        [Route("getTop10")]
        public List<User> getTop10()
        {
            return UserService.getTop10();
        }
        [HttpGet]
        [Route("SpendTime/{id}")]
        public bool SpendTime(int id)
        {
            return UserService.SpendTime(id);
        }
        [HttpGet]
        [Route("ForgetPassword/{email}")]
        public bool ForgetPassword(string email)
        {
            return UserService.ForgetPassword(email);
        }

        [HttpGet]
        [Route("checkPin/{id}/{pin}")]
        public bool checkPin(int id, string pin)
        {
            return UserService.checkPin(id, pin);
        }
        [HttpPost]
        [Route("updateUserChangePin")]
        public bool updateUserChangePin(User userpar)
        {
            return UserService.updateUserChangePin(userpar);
        }
        [Route("uploadImage")]
        [HttpPost]
        public User UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                //byte[] fileContent;
                //using (var ms = new MemoryStream())
                //{
                //    file.CopyTo(ms);
                //    fileContent = ms.ToArray();
                //}
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                //string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".","")}";
                var fullPath = Path.Combine(@"D:\edu\EduSite\src\assets\images", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                User item = new User();
                item.imge = fileName;
                return item;

            }
            catch (Exception e)
            {

                return null;
            }

        }
        [HttpPost]
        [Route("GetFollowingByname")]
        public List<User> getbynameFollowing(User user)
        {
            return UserService.getbynameFollowing(user);
        }
    }
}
