using File_OP.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace File_OP.Interfaces
{
    public interface IProcess
    {
        public Task<Files> SplitAsync(IFormFile files);


    }
}
