using Core.Data;
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
    public class StoryController : Controller
    {
        private readonly IStoryService storyService;

        public StoryController(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool deleteStory(int id)
        {
            return storyService.deleteStory(id);
        }

        [HttpGet]
        [Route("allStory/{id}")]
        public List<storyViewModel> getallStory(int id)
        {
            return storyService.getallStory(id);
        }

        [HttpGet]
        [Route("GetStoryUser")]
        public List<StoryUser> getStoryUser()
        {
            return storyService.getStoryUser();
        }

        [HttpGet]
        [Route("GetById")]
        public Story getbyidStory(int id)
        {
            return storyService.getbyidStory(id);
        }

        [HttpGet]
        [Route("block/{id}")]
        public bool blockStory(int id)
        {
            return storyService.blockStory(id);
        }

        [HttpPost]
        public bool insertStory([FromBody] Story story)
        {
            return storyService.insertStory(story);
        }
        [HttpGet]
        [Route("getallStoryAdmin")]
        public List<Story> getallStoryAdmin()
        {
            return storyService.getallStoryAdmin();
        }

        [HttpPut]
        public bool updateStory(Story story)
        {
            return storyService.updateStory(story);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Story UploadImage()
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
                Story item = new Story();
                item.imagePath = fileName;
                return item;

            }
            catch (Exception e)
            {

                return null;
            }

        }

    }
}
