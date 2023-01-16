using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using GymGymACoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class CategoryTrainerController : Controller
    {
        CategoryTrainerManager ctm = new CategoryTrainerManager(new EfCategoryTrainerRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        TrainerManager tm = new TrainerManager(new EfTrainerRepository());

        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var categoryTrainer = ctm.CategoryTrainerList().ToPagedList(page,pageSize);
            return View(categoryTrainer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
            packetCategoryTrainerModel.Categories = cm.CategoryList();
            packetCategoryTrainerModel.Trainers = tm.TrainerList();
            packetCategoryTrainerModel.CategoryTrainer = new CategoryTrainer();
            return View(packetCategoryTrainerModel);
        }

        [HttpPost]
        public IActionResult Add(CategoryTrainer categoryTrainer)
        {
            PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
            packetCategoryTrainerModel.Categories = cm.CategoryList();
            packetCategoryTrainerModel.Trainers = tm.TrainerList();
            packetCategoryTrainerModel.CategoryTrainer = categoryTrainer;
            CategoryTrainerValidator categoryTrainerValidator = new CategoryTrainerValidator();
            var result = categoryTrainerValidator.Validate(categoryTrainer);
            if (result.IsValid)
            {
                ctm.CategoryTrainerAdd(categoryTrainer);
                return RedirectToAction("Index");

            }
            else
            {
                
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(packetCategoryTrainerModel);
            }

        }

        public IActionResult delete(int id)
        {
            CategoryTrainer categoryTrainer = ctm.CategoryTrainerGetById(id);
            categoryTrainer.Deleted = true;
            ctm.CategoryTrainerUpdate(categoryTrainer);
            return RedirectToAction("Index");
        }
        public IActionResult update(int id)
        {
            PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
            packetCategoryTrainerModel.Categories = cm.CategoryList();
            packetCategoryTrainerModel.Trainers = tm.TrainerList();
            packetCategoryTrainerModel.CategoryTrainer = ctm.CategoryTrainerGetById(id);
            return View(packetCategoryTrainerModel);
        }
        [HttpPost]
        public IActionResult update(CategoryTrainer categoryTrainer)
        {
            CategoryTrainerValidator categoryTrainerValidator = new CategoryTrainerValidator();
            var result = categoryTrainerValidator.Validate(categoryTrainer);
            if (result.IsValid)
            {
                ctm.CategoryTrainerUpdate(categoryTrainer);
                return RedirectToAction("Index");

            }
            else
            {
                PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
                packetCategoryTrainerModel.Categories = cm.CategoryList();
                packetCategoryTrainerModel.Trainers = tm.TrainerList();
                packetCategoryTrainerModel.CategoryTrainer = categoryTrainer;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(packetCategoryTrainerModel);
            }
        }
    }
}
