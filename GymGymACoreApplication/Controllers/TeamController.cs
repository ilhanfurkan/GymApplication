using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class TeamController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var users = um.UserList();
            return View(users);
        }
    }
}
