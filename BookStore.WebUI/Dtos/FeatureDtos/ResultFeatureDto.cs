namespace BookStore.WebUI.Dtos.FeatureDtos
{
    public class ResultFeatureDto
    {
        public int FeatureId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string ProductWriterName { get; set; }
         
        //     

        public int CategoryID { get; set; }
    }
}
