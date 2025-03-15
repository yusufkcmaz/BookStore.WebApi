namespace BookStore.WebApi.Dtos.ApiWriterDto
{
    public class UpdateWriterDto
    {

        public int WriterId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }

    }
}
