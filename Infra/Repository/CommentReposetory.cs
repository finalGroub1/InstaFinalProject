using Core.Common;
using Core.Data;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class CommentReposetory : ICommentReposetory
    {
        private readonly IDBContext _IDBContext;

        public CommentReposetory(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteComment(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofComment", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Comment_F_package.deleteComment", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Comment> getallComment()
        {
            IEnumerable<Comment> result = _IDBContext.Connection.Query<Comment>("Comment_F_package.getallComment", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Comment getbyidComment(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofComment", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Comment>("Comment_F_package.getbyidComment", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertComment(Comment comment)
        {
            var p = new DynamicParameters();
            p.Add("@des", comment.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cDate", comment.date_, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Pid", comment.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid", comment.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cReplayid", comment.comment_reply_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Comment_F_package.insertComment", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateComment(Comment comment)
        {
            var p = new DynamicParameters();
            p.Add("@idofComment", comment.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@des", comment.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cDate", comment.date_, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Pid", comment.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid", comment.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cReplayid", comment.comment_reply_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Comment_F_package.updateComment", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
