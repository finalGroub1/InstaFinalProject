using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IStoryRepository
    {
        public List<Story> getallStory();

        public bool updateStory(Story story);

        public bool deleteStory(int id);

        public bool insertStory(Story story);

        public Story getbyidStory(int id); 
    }
}
