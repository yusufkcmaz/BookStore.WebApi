using BookStore.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore.WebApi.Dtos.ApiCategoryDto
{
    public class ResultCategoryDto
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //Bir kategorinin içinde birden fazla kitap olabilir
        [JsonIgnore]
        public virtual List<Category>? Categories { get; set; }
      
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string ProductWriterName { get; set; }
    }
}
