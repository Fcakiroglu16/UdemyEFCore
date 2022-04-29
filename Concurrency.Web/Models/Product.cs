using System.ComponentModel.DataAnnotations;

namespace Concurrency.Web.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // [Timestamp] 1.yol
        public byte[] RowVersion { get; set; }
    }
}
