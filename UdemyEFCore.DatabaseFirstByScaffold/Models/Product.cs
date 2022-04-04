namespace UdemyEFCore.DatabaseFirstByScaffold.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int? Stock { get; set; }
    }
}