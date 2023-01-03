using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class HourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
