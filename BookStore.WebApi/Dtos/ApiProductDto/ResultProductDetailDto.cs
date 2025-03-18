using BookStore.EntityLayer.Concrete;
using System.Text.Json.Serialization;

namespace BookStore.WebApi.Dtos.ApiProductDto
{
    public class ResultProductDetailDto 
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }

         public int CategoryID { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        public string ProductWriterName { get; set; }
        public string CategoryName { get; set; }
        public string ProductDescription { get; set; }


        


    }
}

