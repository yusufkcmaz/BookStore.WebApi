namespace BookStore.WebApi.Dtos.ApiProductDto
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageUrl { get; set; }

        public string WriterName { get; set; }
        public string CategoryName { get; set; }

    }
}
