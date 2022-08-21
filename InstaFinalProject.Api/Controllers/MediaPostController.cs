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
    public class MediaPostController : Controller
    {
        private readonly IMediaPostService mediaPostService;

        public MediaPostController(IMediaPostService mediaPostService)
        {
            this.mediaPostService = mediaPostService;
        }

        [HttpDelete]
        public bool deleteMediaPost(int id)
        {
            return mediaPostService.deleteMediaPost(id);
        }

        [HttpGet]
        public List<MediaPost> getallMediaPost()
        {
            return mediaPostService.getallMediaPost();
        }

        [HttpGet]
        [Route("GetById")]
        public MediaPost getbyidMediaPost(int id)
        {
            return mediaPostService.getbyidMediaPost(id);
        }

        [HttpPost]
        public bool insertMediaPost(MediaPost media)
        {
            return mediaPostService.insertMediaPost(media);
        }

        [HttpPut]
        public bool updateMediaPost(MediaPost media)
        {
            return mediaPostService.updateMediaPost(media);
        }


        [Route("uploadImage")]
        [HttpPost]
        public MediaPost UploadImage()
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
                MediaPost item = new MediaPost();
                item.mediapath = fileName;
                return item;

            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
