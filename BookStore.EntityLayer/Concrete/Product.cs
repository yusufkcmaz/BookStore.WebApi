﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class Product
    {
        public int  ProductId { get; set; }
        public string  ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [StringLength(100)]
        public string ImageUrl { get; set; }
        public int WriterId { get; set; }
        public Writer? Writer { get; set; } //--> Ürün ile yazar arasında ilişki
        public int CategoryID { get; set; }
        public Category? Category { get; set; }


    }
}
