using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;


namespace GymGymACoreApplication.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());

        public IActionResult Index()
        {
            var users = um.UserList();
            return View(users);
        }
        
    }
}
