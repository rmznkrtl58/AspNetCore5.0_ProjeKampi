using System.ComponentModel.DataAnnotations;

namespace CoreProjeKamp.Models
{
    public class UserRegisterViewModel
    //Identity İle kayıt olma işleminde gerekli olan proplarım
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Adınızı Ve Soyadınızı Giriniz.")]
        public string NameSurname  { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
        public string Password  { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
        [Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor")]
        //Compare->Password'a girilen şifre verisiyle ConfirmPassword'a girilen şifre verisiyle eşleştiğini kontrol eder
        public string ConfirmPassword  { get; set; }
        [Display(Name = "E-posta")]
        [Required(ErrorMessage = "Lütfen E-POSTA adresinizi Giriniz.")]
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Girin.")]
        public string UserName { get; set; }
    }
}
