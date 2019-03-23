using System.ComponentModel.DataAnnotations;

namespace Caelum.Blog.WebApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Display(Name = "Usuário")]
        public string Login { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
