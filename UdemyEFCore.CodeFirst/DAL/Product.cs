using Microsoft.EntityFrameworkCore;

namespace UdemyEFCore.CodeFirst.DAL
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // #######.##
        [Precision(9, 2)]
        public decimal Price { get; set; }

        [Precision(9, 2)]
        public decimal DiscountPrice { get; set; }

        public int Stock { get; set; }

        public int Barcode { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; }

        public virtual ProductFeature ProductFeature { get; set; }
    }
}