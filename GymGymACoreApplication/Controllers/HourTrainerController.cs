using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class HourTrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
