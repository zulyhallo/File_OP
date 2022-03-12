using File_OP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_OP.Interfaces
{
    public interface IFileRepository
    {
        public Task<bool> Save(Files Files);
        public  Task<bool> Upload(List<IFormFile> File);
        public  Task<bool> AddFiles(Files Files);
        IActionResult AddFilesAsync(List<IFormFile> files);
    }
}
