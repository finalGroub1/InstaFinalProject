using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface IStoryService
    {
        public List<Story> getallStory();

        public List<StoryUser> getStoryUser();

        public bool updateStory(Story story);

        public bool deleteStory(int id);

        public bool insertStory(Story story);

        public Story getbyidStory(int id);
    }
}
