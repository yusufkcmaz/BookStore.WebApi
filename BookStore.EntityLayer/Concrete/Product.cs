﻿using System;
using System.Collections.Generic;
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


    }
}
