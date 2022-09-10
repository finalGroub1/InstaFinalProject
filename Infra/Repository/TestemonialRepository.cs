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
    public class TestemonialRepository : ITestemonialRepository
    {
        private readonly IDBContext _IDBContext;

        public TestemonialRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteTestemonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Tid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Testemonial_package.deleteTestemonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Testmonial> getallTestemonial()
        {
            IEnumerable<Testmonial> allTestimonial = _IDBContext.Connection.Query<Testmonial>("Testemonial_package.getallTestemonial", commandType: CommandType.StoredProcedure);
            foreach (var item in allTestimonial)
            {
                item.user = getbyidUser(item.user_id);
            }
            return allTestimonial.ToList();
        }
        public User getbyidUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<User>("User_F_package.getbyidUser", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public Testmonial getbyidTestemonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Tid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Testmonial>("Testemonial_package.getbyidTestemonial", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }
        public bool ChangeState(int id)
        {
            var getbyid = getbyidTestemonial(id);
            if (getbyid.state == 0)
            {
                getbyid.state = 1;
            }
            else if(getbyid.state == 1)
            {
                getbyid.state = 0;
            }
            updateTestemonial(getbyid);
            return true;
        }

        public bool insertTestemonial(Testmonial testmonial)
        {
            var p = new DynamicParameters();
            p.Add("@Tstate", 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tdesc", testmonial.description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Tevaluation", 3, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tuser", testmonial.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Testemonial_package.insertTestemonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateTestemonial(Testmonial testmonial)
        {
            var p = new DynamicParameters();
            p.Add("@Tid", testmonial.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tstate", testmonial.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tdesc", testmonial.description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Tevaluation", 3, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tuser", testmonial.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Testemonial_package.updateTestemonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
