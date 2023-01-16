using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers.InterfaceController
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
