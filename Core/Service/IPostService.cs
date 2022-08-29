using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface IPostService
    {
        public List<Post> getallPost();

        public List<PostUser> getallPostUser();

        public bool updatePost(Post post);

        public bool deletePost(int id);

        public bool insertPost(Post post);

        public Post getbyidPost(int id);

        public bool blockPost(int id);

    }
}
