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
    public class MediaPostRepository : IMediaPostRepository
    {
        private readonly IDBContext _IDBContext;

        public MediaPostRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteMediaPost(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofMediaPost", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("MediaPost_package.deleteMediaPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<MediaPost> getallMediaPost()
        {
            IEnumerable<MediaPost> result = _IDBContext.Connection.Query<MediaPost>("MediaPost_package.getallMediaPost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public MediaPost getbyidMediaPost(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofMediaPost", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<MediaPost>("MediaPost_package.getbyidMediaPost", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public List<MediaStory> getMediaStory()
        {
            IEnumerable<MediaStory> result = _IDBContext.Connection.Query<MediaStory>("getmediastories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<PostMediaDTO> getPostWithMedia()
        {
            IEnumerable<PostMediaDTO> result = _IDBContext.Connection.Query<PostMediaDTO>("getmediapost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool insertMediaPost(MediaPost media)
        {
            var p = new DynamicParameters();
            p.Add("@mPath", media.mediapath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Pid",media.post_id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Sid", media.story_id, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _IDBContext.Connection.ExecuteAsync("MediaPost_package.insertMediaPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateMediaPost(MediaPost media)
        {

            var p = new DynamicParameters();
            p.Add("@idofMediaPost", media.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mPath", media.mediapath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Pid", media.post_id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Sid", media.story_id, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _IDBContext.Connection.ExecuteAsync("MediaPost_package.updateMediaPost", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
