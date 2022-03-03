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
using File = File_OP.Models.Files;
using System.Xml;
using System.Xml.Linq;
using File_OP.DATA;

namespace File_OP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private static IWebHostEnvironment _webHostEnvironmet;
        private readonly MyContext _MyContext;
        public FilesController(MyContext MyContext, IWebHostEnvironment webHostEnvironmet)
        {
            _webHostEnvironmet = webHostEnvironmet;
            _MyContext = MyContext;

        }
        #region XML yükleme 

        [HttpPost]
        [Route("UploadXML")]

        public async Task<string> UploadXML([FromForm] Models.Files obj)
        {
            if (obj.files.Length > 0)
            {
                try
                {   const string FilePath = @"C:\Users\Tech\Desktop\DEFTER\2021-05";
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(FilePath);
                    _MyContext.Files.Add(obj);
                    _MyContext.SaveChanges();
                    return  obj.files.FileName;
                }

                catch (Exception ex)
                {

                    return ex.ToString();
                }
            }
            else
            {
                return "Upload Failed";
            }
        }
        #endregion
    }

}

