using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SignInViewModel
    {
        [EmailAddress(ErrorMessage = "Mail Formatı Hatalı !")]
        [Required(ErrorMessage = "Email Boş Bırakılamaz !")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Boş Bırakılamaz !")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
