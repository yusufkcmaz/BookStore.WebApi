namespace BookStore.WebApi.Dtos.SubscribeDtos
{
    public class ResultSubscribeDto
    {
        public int SubscribeId { get; set; }
        public string Mail { get; set; }
        public DateTime SubcribeDate { get; set; } = DateTime.Now; //->Default tarih atama 
    }
}
