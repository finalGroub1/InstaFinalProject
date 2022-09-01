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

        public bool blockPost(int id)
        {
            var p2 = new DynamicParameters();
            p2.Add("@Pid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var post = _IDBContext.Connection.Query<Post>("Post_package.getbyidPost", p2, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if (post.state == 0)
            {
                post.state = 1;
            }
            else if (post.state == 1)
            {
                post.state = 0;
            }

            var p = new DynamicParameters();
            p.Add("@Pid", post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pcreatedate", post.createdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Pstate", post.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pdesc_", post.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ppostion", post.postion, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Puser_id", post.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Post_package.updatePost", p, commandType: CommandType.StoredProcedure);
            return true;
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
        public List<postViewModel> getallMyPosts(int id)
        {
            var postViewModelList = new List<postViewModel>();
            IEnumerable<Post> post = _IDBContext.Connection.Query<Post>("Post_package.getallPost", commandType: CommandType.StoredProcedure).Where(x=>x.user_id == id).ToList();
            IEnumerable<Comment> comment = _IDBContext.Connection.Query<Comment>("Comment_F_package.getallComment", commandType: CommandType.StoredProcedure);
            IEnumerable<MediaPost> mediaPost = _IDBContext.Connection.Query<MediaPost>("MediaPost_package.getallMediaPost", commandType: CommandType.StoredProcedure);
            IEnumerable<Interaction> interAction = _IDBContext.Connection.Query<Interaction>("InterAction_package.getallInterAction", commandType: CommandType.StoredProcedure);
            //--------------------------------------------------//
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var user = _IDBContext.Connection.Query<User>("User_F_package.getbyidUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();

            //---------------------------------------------
            foreach (var item in post)
            {
                var comm = comment.Where(x => x.post_id == item.id).ToList();
                var med = mediaPost.Where(x => x.post_id == item.id).ToList();
                var inter = interAction.Where(x => x.post_id == item.id).ToList();

                postViewModel Model = new postViewModel()
                {

                    post = item,
                    comment = comm,
                    mediaPost = med,
                    interaction = inter,
                    user = user
                };

                postViewModelList.Add(Model);

            }
            

            return postViewModelList;
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

        public bool insertPost(PostMediaDTO post)
        {
            var p = new DynamicParameters();
            p.Add("@Pcreatedate", DateTime.Now, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Pstate", post.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pdesc_", post.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ppostion", post.postion, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Puser_id", post.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Post_package.insertPost", p, commandType: CommandType.StoredProcedure);
            //---------------------------------------------------------------------------
            var allpost = getallPost();
            var postid= allpost.Where(i => i.user_id == post.user_id).OrderBy(m => m.id).LastOrDefault();


        //----------------------------------------------------
        for(int i=0;i<=post.mediapath.Count-1;i++)
            {
                var p2 = new DynamicParameters();
                p2.Add("@mPath", post.mediapath[i], dbType: DbType.String, direction: ParameterDirection.Input);
                p2.Add("@Pid", postid.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p2.Add("@Sid", null, dbType: DbType.Int32, direction: ParameterDirection.Input);


                 _IDBContext.Connection.ExecuteAsync("MediaPost_package.insertMediaPost", p2, commandType: CommandType.StoredProcedure);
                
            }


            return true;

        }

        public bool updatePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("@Pid", post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pcreatedate", post.createdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Pstate", post.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pdesc_", post.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ppostion", post.postion, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Puser_id", post.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Post_package.updatePost", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
