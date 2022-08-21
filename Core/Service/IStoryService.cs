using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface IStoryService
    {
        public List<Story> getallStory();

        public bool updateStory(Story story);

        public bool deleteStory(int id);

        public bool insertStory(Story story);

        public Story getbyidStory(int id);
    }
}
