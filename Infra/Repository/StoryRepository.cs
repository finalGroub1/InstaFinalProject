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
        private readonly IFollowersRepository _followerrepository;

        public StoryRepository(IDBContext iDBContext, IFollowersRepository followerrepository)
        {
            _IDBContext = iDBContext;
            _followerrepository = followerrepository;
        }

        public bool deleteStory(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofStory", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Story_package.deleteStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<storyViewModel> getallStory(int id)
        {
            IEnumerable<Story> story = _IDBContext.Connection.Query<Story>("Story_package.getallStory", commandType: CommandType.StoredProcedure);
            
            var storyViewModel = new List<storyViewModel>();
            var UserList = _followerrepository.getalluserThatFollow(id);
            foreach (var item in UserList)
            {
                var storyO = story.Where(x => x.user_id == item.id).ToList();
                if (storyO.Count != 0)
                {
                    storyViewModel model = new storyViewModel()
                    {
                        storyList = storyO,
                        user = item

                    };

                    storyViewModel.Add(model);

                }           
                
            }
            //--------------------//

            var Mystory = story.Where(x => x.user_id == id).ToList();
            if (Mystory.Count != 0)
            {
                storyViewModel model = new storyViewModel()
                {
                    storyList = Mystory,
                    user = getbyidUser(id)

                };

                storyViewModel.Add(model);

            }

            return storyViewModel.ToList();
        }
        public User getbyidUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<User>("User_F_package.getbyidUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
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
            p.Add("@Sdesc", story.descrption, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Sstate", story.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SimagePath", story.imagePath, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Story_package.insertStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateStory(Story story)
        {
            var p = new DynamicParameters();
            p.Add("@idofStory", story.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Cdate", story.createdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uid", story.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Sdesc", story.descrption, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Sstate", story.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SimagePath", story.imagePath, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Story_package.updateStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool blockStory(int id)
        {
            var p2 = new DynamicParameters();
            p2.Add("@idofStory", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var story = _IDBContext.Connection.Query<Story>("Story_package.getbyidStory", p2, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if (story.state == 0)
            {
                story.state = 1;
            }
            else if (story.state == 1)
            {
                story.state = 0;
            }

            var p = new DynamicParameters();
            p.Add("@idofStory", story.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Cdate", story.createdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Uid", story.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Sdesc", story.descrption, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Sstate", story.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SimagePath", story.imagePath, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Story_package.updateStory", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
