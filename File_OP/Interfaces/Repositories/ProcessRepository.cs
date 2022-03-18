using File_OP.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace File_OP.Interfaces.Repositories
{
    public class ProcessRepository : IProcess
    {

        public async Task<Files> SplitAsync(IFormFile file)
        {
            string FilePath = @"C:\Users\Tech\Desktop\DEFTER";
            if (file.Length == 0)
                return null;
            else

            {
                Files files = new Files()
                {

                    Path = FilePath + file.FileName,
                    FileName = file.FileName
                };

                char[] separator = new char[] { '-', '/' };
                string[] details = files.FileName.Split(separator);

                files.TaxNumber = details[0];
                files.Year = details[1];
                files.Month = details[2];
                files.Type = details[3];
                files.PeriodNumber = details[4];
                //FileInfo fi = new FileInfo(files.Path);
                //{
                //    files.FileCreateTime = fi.CreationTime;
                //    files.Ext = fi.Extension;
                //}

                return files;
            }
        }
    }
}
//public Task<IActionResult> Split(List<IFormFile> files)
//{
//    string FilePath = @"C:\Users\Tech\Desktop\DEFTER";
//    if (files.Count == 0)
//        return BadRequest();
//    else
//    foreach (var file in files)
//    {
//        Files Files = new Files();
//        {

//            Files.Path = FilePath + file.FileName; 
//            Files.FileName = file.FileName;
//            char[] separator = new char[] { '-', '/' };
//            string[] details = Files.FileName.Split(separator);

//            Files.TaxNumber = details[0];
//            Files.Year = details[1];
//            Files.Month = details[2];
//            Files.Type = details[3];
//            Files.PeriodNumber = details[4];
//            FileInfo fi = new FileInfo(Files.Path);
//            {
//                Files.FileCreateTime = fi.CreationTime;
//                Files.Ext = fi.Extension;
//            }
//        }
//    }
//    return OK(files);
//}