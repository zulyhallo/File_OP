using File_OP.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace File_OP.Interfaces.Repositories
{
    public class FileRepository : IFileRepository //FileValidationService.ValidateAsync(file)
    {
        private readonly DapperContext _dappercontext;
        public FileRepository(DapperContext dappercontext)
        {
            _dappercontext = dappercontext;
        }

        public class ValidationResult
        {
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
        }
        public async Task<ValidationResult> ValidateAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                // return BadRequest();
                return new ValidationResult
                {
                    IsSuccess = false,
                    ErrorMessage = "Dosya Seçilmedi"
                };
            }
            else
            {
                Files Files = new Files();
                Files.Path = Directory.GetCurrentDirectory();
                FileInfo fi = new FileInfo(file.FileName);
                Files.Ext = fi.Extension;
                Files.FileName = fi.FullName;
                if (Files.Ext != ".xml")
                {
                    return new ValidationResult
                    {
                        IsSuccess = false,
                        ErrorMessage = ".xml uzantılı dosya seçilmeli"
                    };
                }
                else
                    return new ValidationResult() { IsSuccess = true };
            }
        }






    }
}

//if public Task<bool> Save(Files Files)
//{
//    throw new NotImplementedException();
//}
//public async Task<bool> Save(Files Files)
//{

//    using (var con = _dappercontext.CreateConnection())
//    {
//        var result1 = await con.ExecuteAsync("SP_SAVE", Files, CommandType.StoredProcedure);

//        var result2 = await con.QueryAsync<Files>("sp_GETFILES", Files, CommandType.StoredProcedure);
//    }

//    return true;
//} 

