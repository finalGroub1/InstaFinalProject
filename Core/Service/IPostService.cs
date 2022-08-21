using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
   public interface IPostService
    {
        public List<Post> getallPost();

        public bool updatePost(Post post);

        public bool deletePost(int id);

        public bool insertPost(Post post);

        public Post getbyidPost(int id);
    }
}
