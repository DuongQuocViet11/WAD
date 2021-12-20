using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên liên lạc")]
        public int ContactNumber { get; set; }
        public string GroupName { get; set; }
        public string HireDate { get; set;  }

        public string Birthday { get; set; }
    }
}