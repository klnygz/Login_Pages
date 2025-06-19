using Entities.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();

            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUsername",
                    Description = "Şifre Alanı Kullanıcı Adı İçeremez."
                });
            }

            if (password!.ToLower().StartsWith("1234"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordStartsWith1234",
                    Description = "Şifre Alanı 1234 İle Başlayamaz."
                });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
