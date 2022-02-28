using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}