using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using File_OP.Models;


namespace File_OP.DATA
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Files> Files { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
