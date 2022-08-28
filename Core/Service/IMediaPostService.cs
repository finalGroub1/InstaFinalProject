using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
  public  interface IMediaPostService
    {
        public List<MediaPost> getallMediaPost();

        public bool updateMediaPost(MediaPost media);

        public bool deleteMediaPost(int id);

        public bool insertMediaPost(MediaPost media);

        public MediaPost getbyidMediaPost(int id);

        public List<MediaStory> getMediaStory();

        public List<PostMediaDTO> getPostWithMedia();


    }
}
