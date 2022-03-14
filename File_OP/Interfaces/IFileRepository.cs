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
        public Task<IActionResult> UploadFileAsync(IFormFile file);
        //public  Task<Files> UploadFileAsync(List<IFormFile> file);
        public  Task<bool> Save(Files Files);
    
        
    }
}
