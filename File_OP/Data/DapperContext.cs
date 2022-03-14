using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_OP.Data
{
    public class DapperContext

    {
        private readonly IConfiguration _configuration;
        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string con = @"Data Source=TDESTEK;Initial Catalog=FSDB;Integrated Security=True;";

        internal IDisposable CreateConnection()
        {
            open
        }


    }
}
