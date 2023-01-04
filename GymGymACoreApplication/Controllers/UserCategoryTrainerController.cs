using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class UserCategoryTrainerController : Controller
    {
        UserCategoryTrainerManager uctm = new UserCategoryTrainerManager(new EfUserCategoryTrainerRepository());
        // GET: UserCategoryTrainerController
        public ActionResult Index()
        {
            var userCategoryTrainer = uctm.UserCategoryTrainerList();
            return View(userCategoryTrainer);
        }
        public IActionResult Delete(int id)
        {
            UserCategoryTrainer userCategoryTrainer = uctm.UserCategoryTrainerGetById(id);
            userCategoryTrainer.Deleted = true;
            uctm.UserCategoryTrainerUpdate(userCategoryTrainer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserCategoryTrainer userCategoryTrainer)
        {
            UserCategoryTrainerValidator userCategoryTrainerValidator = new UserCategoryTrainerValidator();
            var result = userCategoryTrainerValidator.Validate(userCategoryTrainer);
            if (result.IsValid)
            {
                uctm.UserCategoryTrainerAdd(userCategoryTrainer);
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
            UserCategoryTrainer userCategoryTrainer = uctm.UserCategoryTrainerGetById(id);
            return View(userCategoryTrainer);

        }
        [HttpPost]
        public IActionResult Update(UserCategoryTrainer userCategoryTrainer)
        {
            UserCategoryTrainerValidator userCategoryTrainerValidator = new UserCategoryTrainerValidator();
            var result = userCategoryTrainerValidator.Validate(userCategoryTrainer);
            if (result.IsValid)
            {
                uctm.UserCategoryTrainerUpdate(userCategoryTrainer);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(userCategoryTrainer);
            }
        }



    }
}
