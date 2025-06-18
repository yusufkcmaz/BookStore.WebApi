using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Dtos.UserDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email boş geçilemez")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
