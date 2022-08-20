using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentReposetory commentRepository;

        public CommentService(ICommentReposetory commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public bool deleteComment(int id)
        {
            return commentRepository.deleteComment(id);
        }

        public List<Comment> getallComment()
        {
            return commentRepository.getallComment();
        }

        public Comment getbyidComment(int id)
        {
            return commentRepository.getbyidComment(id);
        }

        public bool insertComment(Comment comment)
        {
            return commentRepository.insertComment(comment);
        }

        public bool updateComment(Comment comment)
        {
            return commentRepository.updateComment(comment);
        }
    }
}
