using BookStore.EntityLayer.Concrete;

namespace BookStore.WebUI.Dtos.ProductsDtos
{
    public class GetRandomProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public int WriterId { get; set; }
        public Writer? Writer { get; set; } //--> Ürün ile yazar arasında ilişki
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
