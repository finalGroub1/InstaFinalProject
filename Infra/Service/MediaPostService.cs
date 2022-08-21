using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class MediaPostService : IMediaPostService
    {
        private readonly IMediaPostRepository mediaPostRepository;

        public MediaPostService(IMediaPostRepository mediaPostRepository)
        {
            this.mediaPostRepository = mediaPostRepository;
        }

        public bool deleteMediaPost(int id)
        {
            return mediaPostRepository.deleteMediaPost(id);
        }

        public List<MediaPost> getallMediaPost()
        {
            return mediaPostRepository.getallMediaPost();
        }

        public MediaPost getbyidMediaPost(int id)
        {
            return mediaPostRepository.getbyidMediaPost(id);
        }

        public bool insertMediaPost(MediaPost media)
        {
            return mediaPostRepository.insertMediaPost(media);
        }

        public bool updateMediaPost(MediaPost media)
        {
            return mediaPostRepository.updateMediaPost(media);
        }
    }
}
