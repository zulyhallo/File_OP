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

        public string TaxNumber { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public string PeriodNumber { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string Ext { get; set; }

        //public string F_Hash { get; set; }

   
    }
}
