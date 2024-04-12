using GestionNegocios_PruebraTecnica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestionNegocios_PruebraTecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(SD.Admin))
            {
                return RedirectToAction("Index", "Negocios");
            }
            else if (User.IsInRole(SD.User))
            {
                return RedirectToAction("Index", "ItemMenus");
            }
            else
            {
                // Handle other roles or scenarios
                return View();
            }
           
        }
        [Authorize(Roles = SD.Admin)]
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
