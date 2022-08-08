using Core.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Infra.Common
{
    public class DBContext : IDBContext
    {
        private DbConnection _connection;
        private readonly IConfiguration _configuration;
        public DBContext(IConfiguration configuration)//constrctor
        {
            _configuration = configuration;
        }
        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {

                    _connection = new OracleConnection(_configuration["ConnectionStrings:DbConnectionString"]); // لازم يكون نفس اسم الكونكشن سترينج 

                    _connection.Open();
                }
                else if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }
    }
}
