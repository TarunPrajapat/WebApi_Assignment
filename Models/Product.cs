using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDay1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QtyInStock { get; set; }
        public string Description { get; set; }
        public string Supplier { get; set; }
    }
}