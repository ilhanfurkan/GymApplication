using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using FluentValidation;
using GymGymACoreApplication.Models;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class UserCategoryTrainerController : Controller
    {
        UserCategoryTrainerManager uctm = new UserCategoryTrainerManager(new EfUserCategoryTrainerRepository());
        CategoryTrainerManager ctm = new CategoryTrainerManager(new EfCategoryTrainerRepository());
        UserManager um = new UserManager(new EfUserRepository());
        // GET: UserCategoryTrainerController
        public ActionResult Index(int page = 1,string searchText="")
        {
            //var userCategoryTrainer = uctm.UserCategoryTrainerList().ToPagedList(page,pageSize);
            //return View(userCategoryTrainer);
            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<UserCategoryTrainer> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Registrations.Where(usr => usr.User.FirstName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Registrations.Where(usr => usr.User.FirstName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Registrations.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Registrations.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "UserCategoryTrainer";
            ViewBag.searchText = searchText;
            return View(data);
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
            RegistrationPacketUserModel registrationPacketUserModel = new RegistrationPacketUserModel();
            registrationPacketUserModel.CategoryTrainers = ctm.CategoryTrainerList();
            registrationPacketUserModel.Users = um.UserList();
            registrationPacketUserModel.UserCategoryTrainer = new UserCategoryTrainer();
            return View(registrationPacketUserModel);
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
                RegistrationPacketUserModel registrationPacketUserModel = new RegistrationPacketUserModel();
                registrationPacketUserModel.CategoryTrainers = ctm.CategoryTrainerList();
                registrationPacketUserModel.Users = um.UserList();
                registrationPacketUserModel.UserCategoryTrainer = userCategoryTrainer;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(registrationPacketUserModel);
            }

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            RegistrationPacketUserModel registrationPacketUserModel = new RegistrationPacketUserModel();
            registrationPacketUserModel.CategoryTrainers = ctm.CategoryTrainerList();
            registrationPacketUserModel.Users = um.UserList();
            registrationPacketUserModel.UserCategoryTrainer = uctm.UserCategoryTrainerGetById(id);
            return View(registrationPacketUserModel);

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
                RegistrationPacketUserModel registrationPacketUserModel = new RegistrationPacketUserModel();
                registrationPacketUserModel.CategoryTrainers = ctm.CategoryTrainerList();
                registrationPacketUserModel.Users = um.UserList();
                registrationPacketUserModel.UserCategoryTrainer = userCategoryTrainer;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(registrationPacketUserModel);
            }
        }



    }
}
