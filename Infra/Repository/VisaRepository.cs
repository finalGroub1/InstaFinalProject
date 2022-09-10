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
        private readonly IServiceUserRepository _serviceUser;

        public VisaRepository(IDBContext iDBContext, IServiceUserRepository serviceUser)
        {
            _IDBContext = iDBContext;
            _serviceUser = serviceUser;
        }

        public bool deleteVisa(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofVisa", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("Visa_package.deleteVisa", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool Chickvisa(Visa visa)
        {
            var getvisa = getbyidVisa(visa.id);
            var getservice = getbyidService(visa.ServiceId);
            
            if(getservice.price <= getvisa.amount)
            {
                ServiceUser model = new ServiceUser()
                {
                    post_id = visa.postId,
                    service_id = visa.ServiceId,
                    user_id = visa.user_id                    

                };
                getvisa.amount -= getservice.price;
                updateVisa(getvisa);
                _serviceUser.insertServiceUser(model);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Service_F getbyidService(int id)
        {
            var p = new DynamicParameters();
            p.Add("@idofService", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Service_F>("Service_F_package.getbyidService", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public List<Visa> getallVisa(int id)
        {
            
            IEnumerable<Visa> result = _IDBContext.Connection.Query<Visa>("Visa_package.getallVisa", commandType: CommandType.StoredProcedure).Where(x=> x.user_id == id);
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
            p.Add("@Vamount", visa.amount, dbType: DbType.Double, direction: ParameterDirection.Input);

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
            p.Add("@Vamount", visa.amount, dbType: DbType.Double, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("Visa_package.updateVisa", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
