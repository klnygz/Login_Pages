using System.Diagnostics;
using Application.ViewModels;
using Entities.Entity;
using Login_Pages_UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Application.Extenisons;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Login_Pages_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            }, model.ConfirmPassword);


            if (identityResult.Succeeded)
            {
                ViewBag.SuccessMessage = "Kay�t ��lemi Ba�ar�yla Ger�ekle�tirilmi�tir";

                return View();
            }

            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());

            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var hasUser = await _userManager.FindByEmailAsync(model.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email yada �ifre hatal�.");
                return View();
            }

            var SignInresult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);

            if (SignInresult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            if (SignInresult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>()
                {
                    "Hesab�n�z kilitlenmi�tir. L�tfen 3 dakika sonra tekrar deneyiniz."
                });
                return View();
            }



            ModelState.AddModelErrorList(new List<string>()
            {
                "Email yada �ifre hatal�.",$"Ba�ar�s�z Giri� Say�s� {await _userManager.GetAccessFailedCountAsync(hasUser)}."
            });
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
