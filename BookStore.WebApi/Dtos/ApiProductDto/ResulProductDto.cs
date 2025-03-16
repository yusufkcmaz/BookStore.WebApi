using BookStore.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApi.Dtos.ApiProductDto
{
    public class ResulProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        public string ImageUrl { get; set; }
        public int WriterId { get; set; }
   
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
