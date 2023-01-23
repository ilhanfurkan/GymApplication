using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using GymGymACoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymGymACoreApplication.Controllers
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
            MenuManager manager = new MenuManager(new EfMenuRepository());
            var menuList = manager.MenuList();
            return View(menuList);
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