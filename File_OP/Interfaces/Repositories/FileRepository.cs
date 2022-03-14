using File_OP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Xml;
using System.Xml.Linq;
using File_OP.DATA;
using System.Data;
using Dapper;
using File_OP.Interfaces;
using File_OP.Services;
using File_OP.Data;
using System.IO.Compression;

namespace File_OP.Interfaces.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly DapperContext _dappercontext;
        public FileRepository(DapperContext dappercontext)
        {
            _dappercontext = dappercontext;
        }
        

        public  Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
               // return BadRequest();
               return ("Dosya Seçilmedi");
            }
            else 
            {
                Files Files = new Files();
                Files.Path = Directory.GetCurrentDirectory();
                FileInfo fi = new FileInfo(Files.Path);
                Files.Ext = fi.Extension;
                Files.FileName = fi.FullName;
                if (Files.Ext != ".xml")
                {
                    return Response(".xml uzantılı dosya seçilmeli");
                }
                else
                    return true;
            }

            return OK(file);
        }



        //if public Task<bool> Save(Files Files)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> Save(Files Files)
        {

            using (var con = _dappercontext.CreateConnection())
            {
                var result1 = await con.ExecuteAsync("sp_AddFiles", Files, CommandType.StoredProcedure);
                
            }
            return true;
        }

    }
}


//public async Task<bool> Save(Files Files)
//{

//    using (var con = _dappercontext.CreateConnection())
//    {
//        var result1 = await con.ExecuteAsync("SP_SAVE", Files, CommandType.StoredProcedure);

//        var result2 = await con.QueryAsync<Files>("sp_GETFILES", Files, CommandType.StoredProcedure);
//    }

//    return true;
//} 

