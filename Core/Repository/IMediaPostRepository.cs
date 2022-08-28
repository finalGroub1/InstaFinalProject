using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IMediaPostRepository
    {
        public List<MediaPost> getallMediaPost();

        public bool updateMediaPost(MediaPost media);

        public bool deleteMediaPost(int id);

        public bool insertMediaPost(MediaPost media);

        public MediaPost getbyidMediaPost(int id);

        public List<MediaStory> getMediaStory();

    }
}
