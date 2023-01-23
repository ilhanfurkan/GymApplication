using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using GymGymACoreApplication.Models;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class UserHourTrainerController : Controller
    {
        HourTrainerManager ht = new HourTrainerManager(new EfHourTrainerRepository());
        UserManager um = new UserManager(new EfUserRepository());   
        UserHourTrainerManager uhtm = new UserHourTrainerManager(new EfUserHourTrainerRepository());
        public IActionResult Index(int page = 1,string searchText="")
        {
            //var userHour = uhtm.UserHourTrainerList().ToPagedList(page,pageSize);
            //return View(userHour);
            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<UserHourTrainer> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Appointments.Where(usr => usr.User.FirstName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Appointments.Where(usr => usr.User.FirstName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Appointments.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Appointments.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "UserHourTrainer";
            ViewBag.searchText = searchText;
            return View(data);
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
            appointmentSeanceUserModel.HourTrainers = ht.HourTrainerList();
            appointmentSeanceUserModel.Users = um.UserList();
            appointmentSeanceUserModel.UserHourTrainer = new UserHourTrainer();
            return View(appointmentSeanceUserModel);
        }

        [HttpPost]
        public IActionResult Add(UserHourTrainer userHourTrainer)
        {
             AppointmentSeanceUserModel appointmentSeanceUserModel = new AppointmentSeanceUserModel();
                appointmentSeanceUserModel.HourTrainers = ht.HourTrainerList();
                appointmentSeanceUserModel.Users = um.UserList();
                appointmentSeanceUserModel.UserHourTrainer = new UserHourTrainer();
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
                return View(appointmentSeanceUserModel);
            }

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            AppointmentSeanceUserModel appointmentSeanceUserModel = new AppointmentSeanceUserModel();
            appointmentSeanceUserModel.HourTrainers = ht.HourTrainerList();
            appointmentSeanceUserModel.Users = um.UserList();
            appointmentSeanceUserModel.UserHourTrainer = uhtm.UserHourTrainerGetById(id);
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
                appointmentSeanceUserModel.HourTrainers = ht.HourTrainerList();
                appointmentSeanceUserModel.Users = um.UserList();
                appointmentSeanceUserModel.UserHourTrainer = userHourTrainer;
                foreach (var item in result.Errors)

                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                   
                }
                return View(appointmentSeanceUserModel);
            }
        }


    }
}
