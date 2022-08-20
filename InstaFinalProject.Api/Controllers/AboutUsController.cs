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
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            this.aboutUsService = aboutUsService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteAbout(int id)
        {
            return aboutUsService.deleteAbout(id);
        }

        [HttpGet]
        public List<Aboutus> getallAbout()
        {
            return aboutUsService.getallAbout();
        }

        [HttpGet]
        [Route("GetById")]
        public Aboutus getbyidAbout(int id)
        {
            return aboutUsService.getbyidAbout(id);
        }

        [HttpPost]
        public bool insertAbout(Aboutus aboutus)
        {
            return aboutUsService.insertAbout(aboutus);
        }

        [HttpPut]
        public bool updateAbout(Aboutus aboutus)
        {
            return aboutUsService.updateAbout(aboutus);
        }

        #region UploadImage1

        [Route("uploadImage1")]
        [HttpPost]
        public Aboutus UploadImage()
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
                Aboutus item = new Aboutus();
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
        public Aboutus UploadImage2()
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
                Aboutus item = new Aboutus();
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
