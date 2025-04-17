using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı :")]
        public string Username { get; set; }

        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Display(Name = "Telefon Numarası :")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Parola :")]
        public string Password { get; set; }

        [Display(Name = "Parola Tekrarı :")]
        public string ConfirmPassword { get; set; }
    }
}
