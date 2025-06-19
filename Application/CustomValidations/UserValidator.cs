using Entities.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomValidations
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();

            var isNumeric = int.TryParse(user.UserName[0]!.ToString(), out _);

            if (isNumeric)
            {
                errors.Add(new()
                {
                    Code = "UsernameStartsWithNumber",
                    Description = "Kullanıcı Adı Sayı İle Başlayamaz."
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
