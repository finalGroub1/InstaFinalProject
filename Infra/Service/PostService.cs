using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public bool blockPost(int id)
        {
            return postRepository.blockPost(id);
        }

        public bool deletePost(int id)
        {
            return postRepository.deletePost(id);
        }

        public List<Post> getallPost()
        {
            return postRepository.getallPost();
        }

        public List<PostUser> getallPostUser()
        {
            return postRepository.getallPostUser();
        }

        public Post getbyidPost(int id)
        {
            return postRepository.getbyidPost(id);
        }

        public bool insertPost(Post post)
        {
            return postRepository.insertPost(post);
        }

        public bool updatePost(Post post)
        {
            return postRepository.updatePost(post);
        }
    }
}
