using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bayi.DataAccess
{
    public class Error
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string Information { get; set; }
        public string Path { get; set; }
        public string  Username { get; set; }
    }
}
