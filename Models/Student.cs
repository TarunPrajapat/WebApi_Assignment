using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDay1.Models
{
    public class Student
    {
        public int StudentId { get; set;  }
        public string Name { get; set; }
       public string Batch { get; set; } 
        public int? Marks { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}