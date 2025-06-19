using Entities.Entity;
using Login_Pages_UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login_Pages_UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminHomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();


            var userViewModelList = userList.Select(x => new UserViewModel()
            {
                Id = x.Id,
                Name = x.UserName,
                Email = x.Email
            }).ToList();

            return View(userViewModelList);
        }
    }
}
