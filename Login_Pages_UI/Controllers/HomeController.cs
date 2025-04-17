using System.Diagnostics;
using Application.ViewModels;
using Entities.Entity;
using Login_Pages_UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Login_Pages_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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
            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            }, model.ConfirmPassword);

            if (identityResult.Succeeded)
            {
                ViewBag.SuccessMessage = "Kayýt Ýþlemi Baþarýyla Gerçekleþtirilmiþtir";

                return View();
            }

            foreach (IdentityError item in identityResult.Errors)
            {
               ModelState.AddModelError(string.Empty, item.Description);
            }

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
