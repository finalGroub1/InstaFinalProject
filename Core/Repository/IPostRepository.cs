using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
 public  interface IPostRepository
    {
        public List<Post> getallPost();

        public List<PostUser> getallPostUser();

        public bool updatePost(Post post);

        public bool deletePost(int id);

        public bool insertPost(PostMediaDTO post);

        public Post getbyidPost(int id);

        public bool blockPost(int id);
        public List<postViewModel> getallMyPosts(int id);
        public List<postViewModel> getallFollowingPosts(int id);
        public bool AdmindeletePost(int id);

    }
}
