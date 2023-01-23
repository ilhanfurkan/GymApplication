using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
   
    public class TrainerController : Controller
    {
        TrainerManager tm = new TrainerManager(new EfTrainerRepository());

        // GET: TrainerController
        public IActionResult Index(int page = 1,string searchText="")
        {
            //var trainer = tm.TrainerList().ToPagedList(page,pageSize);
            //return View(trainer);
            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<Trainer> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Trainers.Where(usr => usr.TrainerFirstName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Trainers.Where(usr => usr.TrainerFirstName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Trainers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Trainers.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "Trainer";
            ViewBag.searchText = searchText;
            return View(data);
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
