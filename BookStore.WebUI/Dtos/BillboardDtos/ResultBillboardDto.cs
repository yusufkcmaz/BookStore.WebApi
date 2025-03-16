using BookStore.EntityLayer.Concrete;

namespace BookStore.WebUI.Dtos.BillboardDtos
{
    public class ResultBillboardDto
    //{
    //    //public int BillboardId { get; set; }
    //    public string BookName { get; set; }
    //    public string Description { get; set; }
    //    public string ImageUrl { get; set; }
    //    public string WriterName { get; set; }



    {



        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }

        //[JsonIgnore]
        public virtual Category Category { get; set; }
        public string WriterName { get; set; }
        public string Surname { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }





    }
}





