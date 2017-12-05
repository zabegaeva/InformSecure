using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace InformSecur.Models
{
    public class FileContext : DbContext
    {
        public FileContext():base("DefaultConnection") {}
        public DbSet<File> Files { get; set; }

    }
}