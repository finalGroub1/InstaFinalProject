using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
   public interface ICommentReposetory
    {
        public List<Comment> getallComment();

        public bool updateComment(Comment comment);

        public bool deleteComment(int id);

        public bool insertComment(Comment comment);

        public Comment getbyidComment(int id);
    }
}
