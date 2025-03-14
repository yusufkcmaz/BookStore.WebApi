using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApi.Dtos.ApiProductDto
{
    public class CreateProductDto
    {
  
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStok { get; set; }

        [Required(ErrorMessage = "Product image URL is required.")]
        [Url(ErrorMessage = "Please provide a valid URL.")]
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public int WriterId { get; set; }
        public int CategoryId { get; set; }
    }
}
