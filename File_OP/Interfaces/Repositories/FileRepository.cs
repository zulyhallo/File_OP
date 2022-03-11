using File_OP.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace File_OP.Interfaces.Repositories
{
    public class FileRepository : IFileRepository
    {
        public async Task<bool> Save(Files Files)
        {

            using (var con = _dappercontext.CreateConnection())
            {
                var result1 = await con.ExecuteAsync("SP_SAVE", Files, CommandType.StoredProcedure);

                var result2 = await con.QueryAsync<Files>("SP_GETFILES", Files, CommandType.StoredProcedure);
            }
           
            return true;
        }

        public Task<bool> Upload(List<IFormFile> File)
        {
            throw new NotImplementedException();
        }
    }
}
