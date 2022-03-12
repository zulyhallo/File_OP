using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace File_OP.Services
{
    public class DapperRepository : IDapperRepository // IDapper Interface ni implement edip metotların oluşturulması. Bu metotlar projeye göre özelleşebilir. CRUD işlemleri için:
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "File_OP"; // SqlConnectionString tanımlaması
        public DapperRepository(IConfiguration config)  
        {
            _config = config;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T execute_sp<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString("File_OP"));
            return db.Query<T>(query, sp_params, commandType: commandType).ToList();
        }

        public DbConnection GetDbconnection()
        {
            throw new NotImplementedException();
        }
    }
}
