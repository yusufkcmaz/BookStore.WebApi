namespace BookStore.WebUI.Dtos.FeatureDtos
{
    public class ResultFeatureDto
    {
        public int FeatureId { get; set; }
        public string ImageUrl { get; set; }
        public string BookName { get; set; }
        public string? Description { get; set; }
        public string WriterName { get; set; }
    }
}
