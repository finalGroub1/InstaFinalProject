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
    public class HomeRepository : IHomeRepository
    {
        private readonly IDBContext _IDBContext;

        public HomeRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteHome(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Hid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Home_package.deleteHome", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Home> getallHome()
        {
            IEnumerable<Home> result = _IDBContext.Connection.Query<Home>("Home_package.getallHome", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Home getbyidHome(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Hid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Home>("Home_package.getbyidHome", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertHome(Home home)
        {
            var p = new DynamicParameters();
            p.Add("@Hdesc1", home.description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Hdesc2", home.description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Himg1", home.imge1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Himg2", home.imge2, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Home_package.insertHome", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateHome(Home home)
        {
            var p = new DynamicParameters();
            p.Add("@Hid", home.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Hdesc1", home.description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Hdesc2", home.description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Himg1", home.imge1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Himg2", home.imge2, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Home_package.updateHome", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
