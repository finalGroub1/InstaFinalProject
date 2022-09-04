using Core.Common;
using Core.Data;
using Core.DTO;
using Core.Repository;
using Dapper;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Infra.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDBContext _IDBContext;

        public ReportRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteReport(int id)
        {
            var report = _IDBContext.Connection.Query<Report>("Report_F_package.getallReport", commandType: CommandType.StoredProcedure).Where(x=> x.post_id == id).ToList();
            foreach (var item in report)
            {
                var p = new DynamicParameters();
                p.Add("@idofReport", item.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = _IDBContext.Connection.ExecuteAsync("Report_F_package.deleteReport", p, commandType: CommandType.StoredProcedure);
                
            }
            return true;
            
        }

     
        public User getbyidUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<User>("User_F_package.getbyidUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public Post getbyidPost(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Pid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Post>("Post_package.getbyidPost", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }
        public List<AdminReportDto> getallReport()
        { 
            var report = _IDBContext.Connection.Query<Report>("Report_F_package.getallReport", commandType: CommandType.StoredProcedure).OrderBy(m => m.post_id).ToList();
            var dtoList = new List<AdminReportDto>();

            if (report.Count == 0)
            {
                return dtoList;
            }
            //------------------------------------
            var postIdList = new List<int>();
   
            int prevPostId = 0;
            //------------------------------------
            postIdList.Add(report[0].post_id);
            //--------------------------------------
            
            //--------------------------------------------------------
            for (int i = 0; i < report.Count(); i++)
            {
                report[i].User = getbyidUser(report[i].user_id);
                //---------------------------------
                prevPostId = report[i].post_id;
                //-------------------
                var cheack= postIdList.Where(x => x == prevPostId).FirstOrDefault();
                if(cheack==0)
                {
                    postIdList.Add(report[i].post_id);
                }

            }
          
            //-------------------------------------------
            for (int i = 0; i < postIdList.Count(); i++)
            {
                var med = getallMediaPost(postIdList[i]).ToList();
                foreach (var item3 in med)
                {
                    if (item3.mediapath.Contains("mp4"))
                    {
                        item3.isVideo = 1;
                    }
                    else
                    {
                        item3.isVideo = 0;
                    }
                }
                var post = getbyidPost(postIdList[i]);
                post.User = getbyidUser(post.user_id);

                AdminReportDto model = new AdminReportDto()
                {
                    post = post,
                    report = report.Where(x => x.post_id == postIdList[i]).ToList(),
                    ReportCount = report.Where(x => x.post_id == postIdList[i]).Count(),
                    mediaPostList = med
                };
                dtoList.Add(model);
            }

            return dtoList;
        }
        public List<MediaPost> getallMediaPost(int id)
        {            
            IEnumerable<MediaPost> result = _IDBContext.Connection.Query<MediaPost>("MediaPost_package.getallMediaPost", commandType: CommandType.StoredProcedure).Where(x=> x.post_id == id);
            return result.ToList();
        }

        public Report getbyidReport(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofReport", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Report>("Report_F_package.getbyidReport", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }
        public bool insertReport(Report report)
        {
            var p = new DynamicParameters();
            p.Add("@des",report.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Pid", report.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid", report.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Report_F_package.insertReport", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateReport(Report report)
        {
            var p = new DynamicParameters();
            p.Add("@idofReport", report.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@des", report.desc_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Pid", report.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid", report.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Report_F_package.updateReport", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool userreport(userreport_dto ur)
        {
            var p = new DynamicParameters();
            p.Add("@report_description", ur.report_description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@name", ur.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@post_description", ur.post_description, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("User_F_package.userreport", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<userreport_dto> getuserreport()
        {
            IEnumerable<userreport_dto> result = _IDBContext.Connection.Query<userreport_dto>("User_F_package.userreport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
