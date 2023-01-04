using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class UserHourTrainerController : Controller
    {
        UserHourTrainerManager uhtm = new UserHourTrainerManager(new EfUserHourTrainerRepository());
        public IActionResult Index()
        {
            var userHour = uhtm.UserHourTrainerList();
            return View(userHour);
        }
        public IActionResult Delete(int id)
        {
            UserHourTrainer userHourTrainer = uhtm.UserHourTrainerGetById(id);
            userHourTrainer.Deleted = true;
            uhtm.UserHourTrainerUpdate(userHourTrainer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserHourTrainer userHourTrainer)
        {
            UserHourTrainerValidator userHourTrainerValidator = new UserHourTrainerValidator();
            var result = userHourTrainerValidator.Validate(userHourTrainer);
            if (result.IsValid)
            {
                uhtm.UserHourTrainerAdd(userHourTrainer);
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
            UserHourTrainer userHourTrainer = uhtm.UserHourTrainerGetById(id);
            return View(userHourTrainer);

        }
        [HttpPost]
        public IActionResult Update(UserHourTrainer userHourTrainer)
        {
            UserHourTrainerValidator userHourTrainerValidator = new UserHourTrainerValidator();
            var result = userHourTrainerValidator.Validate(userHourTrainer);
            if (result.IsValid)
            {
                uhtm.UserHourTrainerUpdate(userHourTrainer);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(userHourTrainer);
            }
        }


    }
}
