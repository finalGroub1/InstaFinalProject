using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class postViewModel
    {
        public Post post { get; set; }
        public List<MediaPost> mediaPost { get; set; }
        public List<Comment> comment { get; set; }
        public List<Interaction> interaction { get; set; }
        public User user { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime? ModelPostDate { get; set; }

    }
}
