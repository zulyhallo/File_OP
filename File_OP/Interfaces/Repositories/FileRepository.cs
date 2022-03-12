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

                var result2 = await con.QueryAsync<Files>("sp_GETFILES", Files, CommandType.StoredProcedure);
            }

            return true;
        }

        public IActionResult AddFilesAsync(List<IFormFile> files)
        {
            string FilePath = @"C:\Users\Tech\Desktop\DEFTER";
            if (files.Count == 0)
                return BadRequest();
            foreach (var file in files)
            {
                Files Files = new Files();
                {

                    Files.Path = FilePath + file.FileName; // tekrardan bak!!!!!!!!!!!
                    Files.FileName = file.FileName;
                    char[] separator = new char[] { '-', '/' };
                    string[] details = Files.FileName.Split(separator);

                    Files.TaxNumber = details[0];
                    Files.Year = details[1];
                    Files.Month = details[2];
                    Files.Type = details[3];
                    Files.PeriodNumber = details[4];
                    FileInfo fi = new FileInfo(Files.Path);
                    {
                        Files.FileCreateTime = fi.CreationTime;
                        Files.Ext = fi.Extension;

                    }


                    using (var con = _dappercontext.CreateConnection())
                    {
                        var result = await con.QueryAsync<Files>("sp_AddFiles", Files, CommandType.StoredProcedure);
                    }
                    
                }
                return Ok(files);
            }
            public Task<bool> Upload(List<IFormFile> File)
            {
                throw new NotImplementedException();
            }


            public Task<bool> AddFiles(Files Files)
            {
                throw new NotImplementedException();
            }
        }
    }
}
    

