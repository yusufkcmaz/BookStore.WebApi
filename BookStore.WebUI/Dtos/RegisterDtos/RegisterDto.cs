using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Dtos.RegisterDtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Adınız { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Soyadınız { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string KullanıcıAdı { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Şifre { get; set; }

        [Required(ErrorMessage = "Şifre tekrar boş geçilemez")]
        [Compare("Şifre", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ŞifreTekrar
        {
            get; set;
        }
    }
}