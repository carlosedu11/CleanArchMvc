using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISeedUserRoleInitial _seedUserRoleInital;
        public HomeController(ISeedUserRoleInitial seedUserRoleInitial1)
        {
            _seedUserRoleInital = seedUserRoleInitial1;
            _seedUserRoleInital.SeedRoles();
            _seedUserRoleInital.SeedUsers();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
