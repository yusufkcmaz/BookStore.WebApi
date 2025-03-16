﻿using BookStore.EntityLayer.Concrete;

namespace BookStore.WebUI.Dtos.BillboardDtos
{
    public class ResultBillboardDto



    {


        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string ProductWriterName { get; set; }



        public int CategoryID { get; set; }
        //[JsonIgnore]
        public virtual Category? Category { get; set; }




    }
}





