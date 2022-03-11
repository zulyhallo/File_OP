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

namespace File_OP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileRepository fileRepository;

        public FilesController(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        private readonly IWebHostEnvironment _webHostEnvironment;
        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("Upload")]
        public  IActionResult UploadFilesAsync(List<IFormFile> files)
        {


            //public async Task<bool> UploadFiles(List<IFormFile> files)


            /////// 1. metot
            //var response = await fileRepository.Upload(files);
            //if (!response)
            //{
            //    throw new Exception();
            //}
            //return response;

            /////// 2. metot
            //   Files filess = new Files()
            //{
            //    FileName = "Dosya Adı"
            //    };

            //var result = fileRepository.Save(filess).Result;


            //string FolderPath = @"C:\Users\Tech\Desktop\DEFTER\yedek";
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
                    //  try
                    //  {
                    //
                    //      if (Directory.Exists(FolderPath))
                    //      {
                    //          Console.WriteLine("Klasör var.");
                    //          return;
                    //      }
                    //
                    //      // Try to create the directory.
                    //      DirectoryInfo di = Directory.CreateDirectory(FolderPath);
                    //
                    //
                    //  }
                    //  catch (Exception e)
                    //  {
                    //      Console.WriteLine("The process failed: {0}", e.ToString());
                    //  }
                    //  finally { }


                }
              

         


            }
            return Ok("yükleme tamamlandı");



            //   private static IWebHostEnvironment _webHostEnvironmet;
            //   private readonly MyContext _MyContext;
            //   public FilesController(MyContext MyContext, IWebHostEnvironment webHostEnvironmet)
            //   {
            //       _webHostEnvironmet = webHostEnvironmet;
            //       _MyContext = MyContext;
            //
            //   }
            //   #region XML yükleme 
            //
            //   [HttpPost]
            //   [Route("UploadXML")]
            //
            //   public async Task<string> UploadXML([FromForm] Models.Files obj,string FileName)
            //   {
            //       if (obj.files.Length > 0)
            //       {
            //           try
            //           {   string FilePath = @"C:\Users\Tech\Desktop\DEFTER\2021-05";
            //               XmlDocument xmlDoc = new XmlDocument();
            //               xmlDoc.Load(FilePath);
            //               FileName = xmlDoc.Name;
            //
            //              
            //               return  obj.files.FileName;
            //           }
            //
            //           catch (Exception ex)
            //           {
            //
            //               return ex.ToString();
            //           }
            //       }
            //       else
            //       {
            //           return "Upload Failed";
            //       }
            //   }
            //   #endregion

   



        }
    }
}
