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


        public int? WriterId { get; set; }
      
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
