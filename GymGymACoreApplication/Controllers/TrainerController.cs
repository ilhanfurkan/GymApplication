using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GymGymACoreApplication.Controllers
{

    public class TrainerController : Controller
    {
        TrainerManager tm = new TrainerManager(new EfTrainerRepository());

        // GET: TrainerController
        public IActionResult Index()
        {
            var trainer = tm.TrainerList();
            return View(trainer);
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Trainer trainer) 
        {
            TrainerValidator trainerValidator = new TrainerValidator();
            var result = trainerValidator.Validate(trainer);
            if (result.IsValid)
            {
                tm.TrainerAdd(trainer);
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
            Trainer trainer = tm.TrainerGetById(id); 
            return View(trainer);

        }
        [HttpPost]
        public IActionResult Update(Trainer trainer)
        {
            TrainerValidator trainerValidator = new TrainerValidator();
            var result = trainerValidator.Validate(trainer);
            if (result.IsValid)
            {
                tm.TrainerUpdate(trainer);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(trainer);
            }
        }
        public IActionResult Delete(int id)
        {
            Trainer trainer = tm.TrainerGetById(id);
            trainer.Deleted = true;
            tm.TrainerUpdate(trainer);
            return RedirectToAction("Index");
        }


    }
}
