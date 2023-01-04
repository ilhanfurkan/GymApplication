using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
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
        public IActionResult Delete(int id)
        {
            User user = um.UserGetById(id);
            user.Deleted = true;
            um.UserUpdate(user);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            UserValidator userValidator = new UserValidator();
            var result = userValidator.Validate(user);
            if (result.IsValid)
            {
                um.UserAdd(user);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            User user = um.UserGetById(id);
            return View(user);

        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            UserValidator userValidator = new UserValidator();
            var result = userValidator.Validate(user);
            if (result.IsValid)
            {
                um.UserUpdate(user);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(user);
            }
        }

    }
}
