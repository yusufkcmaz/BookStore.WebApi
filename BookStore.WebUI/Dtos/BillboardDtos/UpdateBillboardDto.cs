namespace BookStore.WebUI.Dtos.BillboardDtos
{
    public class UpdateBillboardDto
    {
        public int BillboardId { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
