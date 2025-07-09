📚 BookStore Web Application
ASP.NET Core RESTful WebAPI kullanılarak geliştirilmiş bir kitap blog sitesidir.
Mimari olarak katmanlı mimari kullanılmıştır.
📌 Bu projedeki amaç: kullanım kolaylığı, revize edilebilirlik ve sürdürülebilirlik sağlamaktır.
--
🚀 Teknik Özellikler

✅ ASP.NET Core 6

✅ Katmanlı Mimari

-Entity

-Data Access

-Business

-WebUI

-WebAPI

✅ ASP.NET Core Identity

✅ RESTful API

✅ MailKit ile SMTP kullanıcıya onay e-posta gönderimi

✅ system.Net.Mail

✅ MVC + Razor Views

✅ DTO kullanımı

✅ AREAS
| Teknoloji                 | Amaç                               |
| ------------------------- | --------------------------------- |
| **ASP.NET Core WebAPI**   | RESTful servisler sağlar           |
| **ASP.NET Core Identity** | Kullanıcı doğrulama, şifre yönetimi ve roller |
| **Entity Framework Core** | ORM ve veritabanı işlemleri        |
| **ASP.NET Core MVC**      | Web arayüzü                       |
| **SQL Server / LocalDB**  | Veritabanı                       |
| **MailKit**               | SMTP ile e-posta gönderimi       |
| **Bootstrap 5**           | Responsive UI                    |

---

### Teknoloji Açıklamaları:

- **ASP.NET Core WebAPI:**  
Kitap, kategori, ürün ve yazar için RESTful servisler sağlar swagger UI arayüzünde test edilir . MVC tabanlı WebUI katmanı bu servisleri tüketerek UI kısmına gösterir.

- **ASP.NET Core Identity:**  
Kullanıcı doğrulama, şifre yönetimi, roller ve e-posta doğrulama işlemleri için güçlü ve güvenli altyapı sunar.Kullanıcı Rollere göre yetki alanına yönelendirilir.

- **MailKit:**  
Kullanıcı Kayıt sırasında ASP.NET Core Identity ile birlikte MailKit kullanılarak doğrulama e-postası gönderilir. Kullanıcı, e-postadaki linke tıklayarak hesabını aktif hale getirir.
ve bu işlemle birlikte güvenlik üst seviyeye çıkarılarak kurumsal yazılımlar hedeflenir.

- **System.Net.Mail:**  
Kullanıcılar e-posta adresleriyle abone olabilir. Aboneler admin panelde listelenebilir ve toplu olarak SMTP üzerinden mail gönderimi yapılabilir. Gönderim için SmtpClient, Gmail SMTP altyapısı ve System.Net.Mail kullanılmıştır.

Admin Paneli:
-
Admin paneli kullanımında yetkililendirilmiş kullanıcılar erişebilerek tüm siteyi dinamik olarak yönetebilir. Dashboard sayfasından tüm istatistikLeri dinamik olarak görebilir ve yönetebilirlik açısından 
kullanım kolaylığı sunar.   
-
✅ Kullanıcıları rollerini yönetebilir. Identity sayesinde kullanılara rol atama işlemi yapılır

✅ Dashboard ana sayfa olarak kullanılır admin girişinde navbara dinamik olarak profil resmi ve ismi getirilir

✅ Admin kendi profilini güncelleyebilir.

✅ Kategori eklenebilir , güncellenebilir .

✅ Abone olan kullanıcılara toplu mail gönderimi yapılabilir .

✅ Ürünler eklenebilir , güncellenebilir.

✅ Rol düzenlenebilir , eklenebilir.


🖼️ Ekran Görüntüleri
-
📧 MAİLKİT KULLANIMI
-
![Adım-1](https://github.com/user-attachments/assets/d13693c2-9c56-43f7-97f8-b40958cb804c)
![Adım-2](https://github.com/user-attachments/assets/61fc7700-7e9b-4538-b267-2750aa02a82a)

👤 KULLANICI-USER PANELİ
-
![Adsız tasarım (4)](https://github.com/user-attachments/assets/b0062782-93e5-48a3-a992-f7e5a732acb2)

🏠 ANA SAYFA
-
![Anasayfa-1](https://github.com/user-attachments/assets/11ccab70-88bf-4fc6-8045-4828c4f08723)

![Anasayfa-2](https://github.com/user-attachments/assets/4d012e6f-1210-48db-b67a-2d62daf252e1)

🖥️ ADMİN PANELİ
-
![Ekran görüntüsü 2025-07-10 010159](https://github.com/user-attachments/assets/75ea44de-7aa5-48dd-97d3-34ee3405a9c2)
![Ekran görüntüsü 2025-07-10 010212](https://github.com/user-attachments/assets/51c4a25b-0576-4171-8e1b-6e7566b3c41c)


![Ekran görüntüsü 2025-07-10 010237](https://github.com/user-attachments/assets/83af7507-7a78-47eb-a0a5-49f9af112760)






