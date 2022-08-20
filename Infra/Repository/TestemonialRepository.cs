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
            IEnumerable<Testmonial> result = _IDBContext.Connection.Query<Testmonial>("Testemonial_package.getallTestemonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testmonial getbyidTestemonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Tid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Testmonial>("Testemonial_package.getbyidTestemonial", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertTestemonial(Testmonial testmonial)
        {
            var p = new DynamicParameters();
            p.Add("@Tstate", testmonial.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tdesc", testmonial.description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Tevaluation", testmonial.evaluation, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Testemonial_package.insertTestemonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateTestemonial(Testmonial testmonial)
        {
            var p = new DynamicParameters();
            p.Add("@Tid", testmonial.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tstate", testmonial.state, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Tdesc", testmonial.description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Tevaluation", testmonial.evaluation, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Testemonial_package.updateTestemonial", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
