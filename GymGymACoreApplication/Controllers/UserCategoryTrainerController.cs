using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using FluentValidation;
using GymGymACoreApplication.Models;
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
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var userCategoryTrainer = uctm.UserCategoryTrainerList().ToPagedList(page,pageSize);
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
            RegistrationPacketUserModel registrationPacketUserModel = new RegistrationPacketUserModel();
            registrationPacketUserModel.packetModel = ctm.CategoryTrainerList();
            registrationPacketUserModel.userModel = um.UserList();
            registrationPacketUserModel.registrationModel = new UserCategoryTrainer();
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
                registrationPacketUserModel.packetModel = ctm.CategoryTrainerList();
                registrationPacketUserModel.userModel = um.UserList();
                registrationPacketUserModel.registrationModel = userCategoryTrainer;
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
            registrationPacketUserModel.packetModel = ctm.CategoryTrainerList();
            registrationPacketUserModel.userModel = um.UserList();
            registrationPacketUserModel.registrationModel = uctm.UserCategoryTrainerGetById(id);
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
                registrationPacketUserModel.packetModel = ctm.CategoryTrainerList();
                registrationPacketUserModel.userModel = um.UserList();
                registrationPacketUserModel.registrationModel = userCategoryTrainer;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(registrationPacketUserModel);
            }
        }



    }
}
