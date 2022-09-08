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
    public class ServiceUserRepository : IServiceUserRepository
    {
        private readonly IDBContext _IDBContext;
        private readonly IPostRepository _IPostRepository;

        public ServiceUserRepository(IDBContext iDBContext, IPostRepository IPostRepository)
        {
            _IDBContext = iDBContext;
            _IPostRepository = IPostRepository;


        }
        public User getbyidUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<User>("User_F_package.getbyidUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

            public bool deleteServiceUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofServiceUser", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("ServiceUser_package.deleteServiceUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ServiceUser> getallServiceUser()
        {
            IEnumerable<MediaPost> mediaPost = _IDBContext.Connection.Query<MediaPost>("MediaPost_package.getallMediaPost", commandType: CommandType.StoredProcedure);
            IEnumerable<ServiceUser> serviceUser = _IDBContext.Connection.Query<ServiceUser>("ServiceUser_package.getallServiceUser", commandType: CommandType.StoredProcedure).ToList();
            foreach (var item in serviceUser)
            {
                item.Service_ = getbyidService(item.service_id);
                item.Post = _IPostRepository.getbyidPost(item.post_id);
                item.Post.MediaPosts = mediaPost.Where(x => x.post_id == item.post_id).ToList();
                item.Post.User = getbyidUser(item.user_id);

                foreach (var item3 in item.Post.MediaPosts)
                {
                    if (item3.mediapath != null && item3.mediapath.Contains("mp4"))
                    {
                        item3.isVideo = 1;
                    }
                    else
                        item3.isVideo = 0;
                }
                {
                }
            }
            return serviceUser.ToList();
        }
        public List<ServiceUser> getallMyserviceUser(int id)
        
        {
            IEnumerable<MediaPost> mediaPost = _IDBContext.Connection.Query<MediaPost>("MediaPost_package.getallMediaPost", commandType: CommandType.StoredProcedure);
            var serviceUser = _IDBContext.Connection.Query<ServiceUser>("ServiceUser_package.getallServiceUser", commandType: CommandType.StoredProcedure).Where(x=> x.user_id == id).ToList();

            foreach (var item in serviceUser)
            {
                item.Service_ = getbyidService(item.service_id);
                item.Post = _IPostRepository.getbyidPost(item.post_id);
                item.Post.MediaPosts = mediaPost.Where(x => x.post_id == item.post_id).ToList();

                foreach (var item3 in item.Post.MediaPosts)
                {
                    if (item3.mediapath != null && item3.mediapath.Contains("mp4"))
                    {
                        item3.isVideo = 1;
                    }
                    else
                        item3.isVideo = 0;
                }
            }
            if(serviceUser.Count != 0) {
                serviceUser.
            }
            
            return serviceUser.ToList();
        }

        public ServiceUser getbyidServiceUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofServiceUser", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<ServiceUser>("ServiceUser_package.getbyidServiceUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }
        public Service_F getbyidService(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofService", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Service_F>("Service_F_package.getbyidService", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertServiceUser(ServiceUser serviceUser)
        {
            var service = getbyidService(serviceUser.service_id);
            serviceUser.datein = DateTime.Now;
            serviceUser.date_to = DateTime.Now.AddMonths(service.duration);
            //-----------------------------------


            //--------------------------------
            var p = new DynamicParameters();
            p.Add("@Servid",serviceUser.service_id , dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid",serviceUser.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pid",serviceUser.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@dIn", serviceUser.datein, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@dTo", serviceUser.date_to, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("ServiceUser_package.insertServiceUser", p, commandType: CommandType.StoredProcedure);

            var user = _IPostRepository.getbyidPost(serviceUser.post_id);
            user.state = 1;
            _IPostRepository.updatePost(user);


            return true;
        }

        public bool updateServiceUser(ServiceUser serviceUser)
        {
            var p = new DynamicParameters();
            p.Add("@idofServiceUser", serviceUser.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Servid", serviceUser.service_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid", serviceUser.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Pid", serviceUser.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@dIn", serviceUser.datein, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@dTo", serviceUser.date_to, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("ServiceUser_package.updateServiceUser", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
