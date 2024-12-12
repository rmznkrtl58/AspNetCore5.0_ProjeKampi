using System.ComponentModel.DataAnnotations;

namespace CoreProjeKamp.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen Role Adını Giriniz!")]
        public string name { get; set; }
    }
}
