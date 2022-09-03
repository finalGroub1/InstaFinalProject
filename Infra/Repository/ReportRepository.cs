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
    public class ReportRepository : IReportRepository
    {
        private readonly IDBContext _IDBContext;

        public ReportRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteReport(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofReport", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Report_F_package.deleteReport", p, commandType: CommandType.StoredProcedure);
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
            var result = _IDBContext.Connection.Query<Report>("Report_F_package.getallReport", commandType: CommandType.StoredProcedure).OrderBy(m => m.post_id).ToList();
            var postIdList = new List<int>();
            int prevPostId = 0;
            //------------------------------------
            postIdList.Add(result[0].post_id);
            //--------------------------------------
            var dtoList = new List<AdminReportDto>();
            //--------------------------------------------------------
            for (int i = 0; i <= result.Count() - 1; i++)
            {
                result[i].User = getbyidUser(result[i].user_id);
                prevPostId = result[i].post_id;
                if (postIdList[i] != prevPostId)
                {
                    postIdList.Add(result[i].post_id);
                }
            }
            //-------------------------------------------
            for (int i = 0; i < postIdList.Count(); i++)
            {

                AdminReportDto model = new AdminReportDto()
                {
                    post = getbyidPost(postIdList[i]),
                    report = result.Where(x => x.post_id == postIdList[i]).ToList()
                };
                dtoList.Add(model);
            }

            return dtoList;
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
