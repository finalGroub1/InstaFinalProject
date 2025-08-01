﻿using Core.Data;
using Core.DTO;
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
        [Route("delete/{id}")]
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
        public bool insertMediaPost([FromBody] MediaPost media)
        {
            return mediaPostService.insertMediaPost(media);
        }

        [HttpPut]
        public bool updateMediaPost(MediaPost media)
        {
            return mediaPostService.updateMediaPost(media);
        }

        [HttpGet]
        [Route("mediaStory")]
        public List<MediaStory> getMediaStory()
        {
            return mediaPostService.getMediaStory();
        }

        [HttpGet]
        [Route("mediaPost")]
        public List<PostMediaDTO> getPostWithMedia()
        {
            return mediaPostService.getPostWithMedia();
        }

        [Route("uploadImage")]
        [HttpPost]
        public MediaPost UploadImage()
        {
            try
            {
                var file = Request.Form.Files;
                for (int i = 0; i < file.Count; i++)
                {   
                    
                        var fileName = Guid.NewGuid().ToString() + "_" + file[i].FileName;
                        var fullPath = Path.Combine(@"C:\Users\Bader Qabooq\Desktop\edu\EduSite\src\assets\images", fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file[i].CopyTo(stream);
                        }
                        MediaPost item = new MediaPost();
                        item.mediapath = fileName;
                        return item;

                    
                }      

            }
            catch (Exception e)
            {

                return null;
            }
            return null;
        }
    }
}
