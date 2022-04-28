using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DTOs
{
    internal class ProductDto2
    {
        public string CategoryName { get; set; }
        public string ProductNames { get; set; }

        public decimal TotalPrice { get; set; }
        public int? TotalWidth { get; set; }
    }
}
