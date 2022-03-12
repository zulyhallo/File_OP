using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
namespace File_OP
{
    public class Program
    {
        public static void Main(string[] args)
        {   using (IDbConnection  conn=new SqlConnection("Data Source=TDESTEK;Initial Catalog=FSDB;Integrated Security=True; "))
            {
                conn.Open();
                conn.Execute("insert into Files () valeus");
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
