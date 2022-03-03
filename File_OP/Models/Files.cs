using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace File_OP.Models
{
    public class Files
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        public string FileName { get; set; }

        public DateTime FileCreateTime { get; set; }

        public int F_TaxNumber { get; set; }

        public int F_Year { get; set; }

        public int F_Month { get; set; }

        public int F_PeriodNumber { get; set; }
        public string F_Type { get; set; }
        public string F_Path { get; set; }

        public string F_Hash { get; set; }

        [NotMapped]
        public IFormFile files { get; set; }
    }
}
