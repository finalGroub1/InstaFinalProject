using Core.Common;
using Core.Data;
using Core.DTO;
using Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IDBContext _IDBContext;

        public PostRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deletePost(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Pid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Post_package.deletePost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Post> getallPost()
        {
            IEnumerable<Post> result = _IDBContext.Connection.Query<Post>("Post_package.getallPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<PostUser> getallPostUser()
        {
            IEnumerable<PostUser> result = _IDBContext.Connection.Query<PostUser>("Post_package.getUserPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Post getbyidPost(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Pid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Post>("Post_package.getbyidPost", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertPost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@Pcreatedate", post.createdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Pstate", post.state, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Pdesc_", post.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ppostion", post.postion, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Puser_id", post.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Post_package.insertPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updatePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@Pid", post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pcreatedate", post.createdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Pstate", post.state, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Pdesc_", post.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ppostion", post.postion, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Puser_id", post.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Post_package.updatePost", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
