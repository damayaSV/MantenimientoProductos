namespace WebProductos.Models
{
    public class ProductDTO
    {
        public int ProuctId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitInStock { get; set; }
    }
}
