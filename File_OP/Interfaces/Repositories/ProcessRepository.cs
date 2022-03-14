using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_OP.Models;
using System.IO;

namespace File_OP.Interfaces.Repositories
{
    public class ProcessRepository : IProcess
    {
        public Task<Files> Split(List<IFormFile> files)
        {
            string FilePath = @"C:\Users\Tech\Desktop\DEFTER";
            if (files.Count == 0)
                return BadRequest();
            else
            foreach (var file in files)
            {
                Files Files = new Files();
                {

                    Files.Path = FilePath + file.FileName; 
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
                }
            }
            return OK(files);
        }

        private Task<Files> BadRequest()
        {
            throw new NotImplementedException();
        }

        private Task<Files> OK(List<IFormFile> files)
        {
            throw new NotImplementedException();
        }
    }
}
