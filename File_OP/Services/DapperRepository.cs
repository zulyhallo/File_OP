using Dapper;
using File_OP.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace File_OP.Services
{
    public class DapperRepository : IDapperRepository // IDapper Interface ni implement edip metotların oluşturulması. Bu metotlar projeye göre özelleşebilir. CRUD işlemleri için:
    {
        private readonly IConfiguration _config;
        private readonly IDapperRepository _dapper;
        private string Connectionstring = "File_OP"; // SqlConnectionString tanımlaması
        public DapperRepository(IConfiguration config, IDapperRepository dapper)
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
            using (IDbConnection con = new SqlConnection("File_OP")) //SOLID Prensipleri araştırılacak öğrenilecek
            {
                return await con.ExecuteAsync("sp_AddFiles", file, commandType: CommandType.StoredProcedure) > 0;
            }
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
