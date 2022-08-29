using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
   public class StoryService: IStoryService
    {
        private readonly IStoryRepository storyRepository;

        public StoryService(IStoryRepository storyRepository)
        {
            this.storyRepository = storyRepository;
        }

        public bool deleteStory(int id)
        {
            return storyRepository.deleteStory(id);
        }

        public List<Story> getallStory()
        {
            return storyRepository.getallStory();
        }

        public List<StoryUser> getStoryUser()
        {
            return storyRepository.getStoryUser();
        }

        public Story getbyidStory(int id)
        {
            return storyRepository.getbyidStory(id);
        }

        public bool insertStory(Story story)
        {
            return storyRepository.insertStory(story);
        }

        public bool updateStory(Story story)
        {
            return storyRepository.updateStory(story);
        }

        public bool blockStory(int id)
        {
            return storyRepository.blockStory(id);
        }
    }
}
