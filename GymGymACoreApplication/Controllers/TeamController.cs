using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
