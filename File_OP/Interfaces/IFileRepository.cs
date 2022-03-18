using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;
using static File_OP.Interfaces.Repositories.FileRepository;

namespace File_OP.Interfaces
{
    public interface IFileRepository
    {
        public Task<ValidationResult> ValidateAsync(IFormFile file); 

    }
}
