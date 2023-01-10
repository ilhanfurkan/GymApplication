using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using GymGymACoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class UserHourTrainerController : Controller
    {
        HourTrainerManager ht = new HourTrainerManager(new EfHourTrainerRepository());
        UserManager um = new UserManager(new EfUserRepository());   
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
            AppointmentSeanceUserModel appointmentSeanceUserModel = new AppointmentSeanceUserModel();
            appointmentSeanceUserModel.seanceModel = ht.HourTrainerList();
            appointmentSeanceUserModel.userModel = um.UserList();
            appointmentSeanceUserModel.appointmentModel = new UserHourTrainer();
            return View(appointmentSeanceUserModel);
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
                AppointmentSeanceUserModel appointmentSeanceUserModel = new AppointmentSeanceUserModel();
                appointmentSeanceUserModel.seanceModel = ht.HourTrainerList();
                appointmentSeanceUserModel.userModel = um.UserList();
                appointmentSeanceUserModel.appointmentModel = userHourTrainer;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(appointmentSeanceUserModel);
            }

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            AppointmentSeanceUserModel appointmentSeanceUserModel = new AppointmentSeanceUserModel();
            appointmentSeanceUserModel.seanceModel = ht.HourTrainerList();
            appointmentSeanceUserModel.userModel = um.UserList();
            appointmentSeanceUserModel.appointmentModel = uhtm.UserHourTrainerGetById(id);
            return View(appointmentSeanceUserModel);

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
     
             

                AppointmentSeanceUserModel appointmentSeanceUserModel = new AppointmentSeanceUserModel();
                appointmentSeanceUserModel.seanceModel = ht.HourTrainerList();
                appointmentSeanceUserModel.userModel = um.UserList();
                appointmentSeanceUserModel.appointmentModel = userHourTrainer;
                foreach (var item in result.Errors)

                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                   
                }
                return View(appointmentSeanceUserModel);
            }
        }


    }
}
