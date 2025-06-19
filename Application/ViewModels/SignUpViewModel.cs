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
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz !")]
        [Display(Name = "Kullanıcı Adı :")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Mail Formatı Hatalı !")]
        [Required(ErrorMessage = "Mail Alanı Boş Bırakılamaz !")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon Alanı Boş Bırakılamaz !")]
        [Display(Name = "Telefon Numarası :")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Parola Boş Bırakılamaz !")]
        [Display(Name = "Parola :")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Parolalar Eşleşmiyor !")]
        [Required(ErrorMessage = "Parola Tekrarı Boş Bırakılamaz !")]
        [Display(Name = "Parola Tekrarı :")]
        public string ConfirmPassword { get; set; }
    }
}
