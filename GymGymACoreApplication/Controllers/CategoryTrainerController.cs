using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class CategoryTrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
