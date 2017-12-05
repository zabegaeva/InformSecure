using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformSecur.Models
{
    public class File
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

    }
}