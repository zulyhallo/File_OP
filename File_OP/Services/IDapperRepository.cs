using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.Common;
using System.Data;

namespace File_OP.Services
{
    interface IDapperRepository: IDisposable
    {
        DbConnection GetDbconnection();
        T execute_sp<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
    }



    //// CRUD işlemleri için 
    //DbConnection GetDbconnection();
    //T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    //List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    ////int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    ////T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    ////T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
}
