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
   public class StoryRepository: IStoryRepository
    {
        private readonly IDBContext _IDBContext;

        public StoryRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteStory(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofStory", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Story_package.deleteStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Story> getallStory()
        {
            IEnumerable<Story> result = _IDBContext.Connection.Query<Story>("Story_package.getallStory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<StoryUser> getStoryUser()
        {
            IEnumerable<StoryUser> result = _IDBContext.Connection.Query<StoryUser>("Story_package.getStoryUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Story getbyidStory(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofStory", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Story>("Story_package.getbyidStory", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }


        public bool insertStory(Story story)
        {
            var p = new DynamicParameters();
            p.Add("@Cdate", story.createdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uid", story.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Sdesc", story.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Sstate", story.state, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Story_package.insertStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateStory(Story story)
        {
            var p = new DynamicParameters();
            p.Add("@idofStory", story.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Cdate", story.createdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uid", story.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Sdesc", story.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Sstate", story.state, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Story_package.updateStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
