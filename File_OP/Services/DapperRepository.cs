using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using File_OP.Models;
using File_OP.Interfaces;

namespace File_OP.Services
{
    public class DapperRepository : IDapperRepository // IDapper Interface ni implement edip metotların oluşturulması. Bu metotlar projeye göre özelleşebilir. CRUD işlemleri için:
    {
        private readonly IConfiguration _config;
        private readonly IDapperRepository _dapper;
        private string Connectionstring = "File_OP"; // SqlConnectionString tanımlaması
        public DapperRepository(IConfiguration config,IDapperRepository dapper)  
        {
            _config = config;
            _dapper = dapper;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Files>> GetFilesAsync()
        {
            return await _dapper.GetFilesAsync();
        }

        public async Task<Files> GetFileByIdAsync(int FileID)
        {
            return await _dapper.GetFileByIdAsync(FileID);
        }

        public async Task<bool> SaveFilesAsync(Files file)
        {
            using (IDbConnection con = new SqlConnection("File_OP"))
           

            {
                 var result = await con.ExecuteAsync("sp_AddFiles", Files, CommandType.StoredProcedure);
                
                    if (result == 1)
                {
                    return await _dapper.SaveFilesAsync(file);
                }
                else
                    return null();
            }
            return true;
        }

        
    }
}
//public T execute_sp<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
//{
//    throw new NotImplementedException();
//}

//public List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
//{
//    using IDbConnection db = new SqlConnection(_config.GetConnectionString("File_OP"));
//    return db.Query<T>(query, sp_params, commandType: commandType).ToList();
//}

//public DbConnection GetDbconnection()
//{
//    throw new NotImplementedException();
