using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ResetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Mail Formatı Hatalı !")]
        [Required(ErrorMessage = "Email Boş Bırakılamaz !")]
        [Display(Name = "Email :")]
        public string Email { get; set; }
    }
}
