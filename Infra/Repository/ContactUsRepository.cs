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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDBContext _IDBContext;

        public ContactUsRepository(IDBContext iDBContext)
        {
            _IDBContext = iDBContext;
        }

        public bool deleteContact(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.ExecuteAsync("ContactUs_package.deleteContact", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Contactus> getallContact()
        {
            IEnumerable<Contactus> result = _IDBContext.Connection.Query<Contactus>("ContactUs_package.getallContact", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Contactus getbyidContact(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _IDBContext.Connection.Query<Contactus>("ContactUs_package.getbyidContact", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }

        public bool insertContact(Contactus contactus)
        {
            var p = new DynamicParameters();
            p.Add("@Cname", contactus.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cmessage", contactus.massege, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cphone", contactus.phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cemail", contactus.email, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("ContactUs_package.insertContact", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updateContact(Contactus contactus)
        {
            var p = new DynamicParameters();
            p.Add("@Cid", contactus.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Cname", contactus.name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cmessage", contactus.massege, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cphone", contactus.phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cemail", contactus.email, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _IDBContext.Connection.ExecuteAsync("ContactUs_package.updateContact", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
