using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());

        public IActionResult Index(int page = 1 ,string searchText="")
        {
            //var users = um.UserList().ToPagedList(page,pageSize);
            //return View(users);
            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<User> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Users.Where(usr => usr.FirstName.Contains(searchText) ||
                usr.LastName.Contains(searchText) ||
                usr.UserLogin.Contains(searchText) ||
                usr.RemainingRight.ToString().Contains(searchText) ||
                usr.NationalId.Contains(searchText) ||
                usr.Height.ToString().Contains(searchText) ||
                usr.Weight.ToString().Contains(searchText) ||
                usr.PhoneNo.Contains(searchText) ||
                usr.Mail.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();


                itemCounts = c.Users.Where(usr => usr.FirstName.Contains(searchText) ||
                usr.LastName.Contains(searchText) ||
                usr.UserLogin.Contains(searchText) ||
                usr.RemainingRight.ToString().Contains(searchText) ||
                usr.NationalId.Contains(searchText) ||
                usr.Height.ToString().Contains(searchText) ||
                usr.Weight.ToString().Contains(searchText) ||
                usr.PhoneNo.Contains(searchText) ||
                usr.Mail.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Users.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "User";
            ViewBag.searchText = searchText;
            return View(data);

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
