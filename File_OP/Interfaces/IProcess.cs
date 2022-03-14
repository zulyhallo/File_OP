using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using File_OP.Models;

namespace File_OP.Interfaces
{
    public interface IProcess
    {
        public Task<Files> Split(List<IFormFile> files);
    

    }
}
