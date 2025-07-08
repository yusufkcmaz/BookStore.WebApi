namespace BookStore.WebUI.Dtos.UserDtos
{
    public class ResultUserDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}

