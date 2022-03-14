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
using File_OP.Interfaces.Repositories;

namespace File_OP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IDapperRepository _dapperRepository;
        private readonly IProcess _process;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FilesController(IFileRepository fileRepository,IDapperRepository dapperRepository,ProcessRepository process)
        {
            this._fileRepository = fileRepository;
            this._dapperRepository = dapperRepository;
            this._process = process;
        }

       
        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("Upload")]

        #region Upload files
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            var response = await FileRepository.UploadFileAsync(file);
            if (!response)
            {
                throw new Exception();
            }
            return response;
        }
        #endregion
        #region Process files
        public async  Task<Files> Split(List<IFormFile> file)
        {
            var response = await ProcessRepository.Split(file);
            if (!response)
            {
                throw new Exception();
            }
            return response;
        }
        #endregion

        #region Save Files
        #endregion



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
        //string FilePath = @"C:\Users\Tech\Desktop\DEFTER";
        //if (files.Count == 0)
        //    return BadRequest();
        //foreach (var file in files)
        //{
        //    Files Files = new Files();
        //    {

        //        Files.Path = FilePath + file.FileName; // tekrardan bak!!!!!!!!!!!
        //        Files.FileName = file.FileName; 
        //        char[] separator = new char[] { '-', '/' };
        //        string[] details = Files.FileName.Split(separator);

        //        Files.TaxNumber = details[0];
        //        Files.Year = details[1];
        //        Files.Month = details[2];
        //        Files.Type = details[3];
        //        Files.PeriodNumber = details[4];
        //        FileInfo fi = new FileInfo(Files.Path);
        //        {
        //            Files.FileCreateTime = fi.CreationTime;
        //            Files.Ext = fi.Extension;

        //}
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
            //return Ok("yükleme tamamlandı");



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

   



