﻿namespace BookStore.WebUI.Dtos.UserDtos
{
    public class UpdateProfilDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }

    }
}
