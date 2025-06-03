using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Product
    { 
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string ProductWriterName { get; set; }
        
        //     
        
        public int CategoryID { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }


    }
}
