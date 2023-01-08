using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        private readonly ILogger<AdminController> _logger;
        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            var admin = adminManager.AdminList();
            return View(admin);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            var result = adminValidator.Validate(admin);
            if (result.IsValid)
            {
                adminManager.AdminAdd(admin);
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
        public IActionResult Delete(int id)
        {
            Admin admin = adminManager.AdminGetById(id);
            admin.Deleted = true;
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Admin admin = adminManager.AdminGetById(id);

            return View(admin);
        }
        [HttpPost]
        public IActionResult Update(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            var result = adminValidator.Validate(admin);
            if (result.IsValid)
            {
                adminManager.AdminUpdate(admin);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(admin);
            }

        }
    }
}
