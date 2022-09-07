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
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteHome(int id)
        {
            return homeService.deleteHome(id);
        }

        [HttpGet]
        public List<Home> getallHome()
        {
            return homeService.getallHome();
        }

        [HttpGet]
        [Route("GetById")]
        public Home getbyidHome(int id)
        {
            return homeService.getbyidHome(id);
        }

        [HttpPost]
        public bool insertHome([FromBody] Home home)
        {
            return homeService.insertHome(home);
        }

        [HttpPut]
        public bool updateHome(Home home)
        {
            return homeService.updateHome(home);
        }


        #region UploadImage1

        [Route("uploadImage1")]
        [HttpPost]
        public Home UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine(@"D:\edu\EduSite\src\assets\images", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home item = new Home();
                item.imge1 = fileName;
                return item;

            }
            catch (Exception e)
            {

                return null;
            }

        }

        #endregion

        #region UploadImage2
        [Route("uploadImage2")]
        [HttpPost]
        public Home UploadImage2()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("Src", fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home item = new Home();
                item.imge2 = fileName;
                return item;

            }
            catch (Exception e)
            {

                return null;
            }
        }
        #endregion
    }
}
