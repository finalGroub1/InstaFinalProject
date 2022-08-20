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
    public class AboutUsRepository : IAboutUsRepository
    {
        private readonly IDBContext _IDBContext;

        public AboutUsRepository(IDBContext IDBContext)
        {
            _IDBContext = IDBContext;
        }

        public bool deleteAbout(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Aid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("AboutUs_package.deleteAbout", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Aboutus> getallAbout()
        {
            IEnumerable<Aboutus> result = _IDBContext.Connection.Query<Aboutus>("AboutUs_package.getallAbout", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Aboutus getbyidAbout(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Aid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Aboutus>("AboutUs_package.getbyidAbout", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertAbout(Aboutus aboutus)
        {
            var p = new DynamicParameters();
            p.Add("@Adesc1", aboutus.description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Adesc2", aboutus.description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Aimg1", aboutus.imge1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Aimg2", aboutus.imge2, dbType: DbType.String, direction: ParameterDirection.Input);
          
            var result = _IDBContext.Connection.ExecuteAsync("AboutUs_package.insertAbout", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateAbout(Aboutus aboutus)
        {
            var p = new DynamicParameters();
            p.Add("@Aid", aboutus.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Adesc1", aboutus.description1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Adesc2", aboutus.description2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Aimg1", aboutus.imge1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Aimg2", aboutus.imge2, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("AboutUs_package.updateAbout", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
