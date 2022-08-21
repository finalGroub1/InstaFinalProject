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
    public class VisaRepository : IVisaRepository
    {
        private readonly IDBContext _IDBContext;

        public VisaRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteVisa(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofVisa", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Visa_package.deleteVisa", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Visa> getallVisa()
        {
            IEnumerable<Visa> result = _IDBContext.Connection.Query<Visa>("Visa_package.getallVisa", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Visa getbyidVisa(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofVisa", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Visa>("Visa_package.getbyidVisa", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertVisa(Visa visa)
        {
            var p = new DynamicParameters();
            p.Add("@numV",visa.number_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@nameV", visa.name_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cvvV", visa.cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mmV", visa.mm, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@yyV", visa.yy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid", visa.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Visa_package.insertVisa", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateVisa(Visa visa)
        {
            var p = new DynamicParameters();
            p.Add("@idofVisa", visa.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@numV", visa.number_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@nameV", visa.name_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cvvV", visa.cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mmV", visa.mm, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@yyV", visa.yy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Uid", visa.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Visa_package.updateVisa", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
