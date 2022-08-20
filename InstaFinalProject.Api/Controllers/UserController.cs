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
        [Route("GetById")]
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
        [HttpPut]
        public bool updateUser(User User)
        {
            return UserService.updateUser(User);
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
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\EdueSite\\src\\assets\\images", fileName);
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
    }
}
