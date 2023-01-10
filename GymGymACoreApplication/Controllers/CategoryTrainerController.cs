using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using GymGymACoreApplication.Models;
using Microsoft.AspNetCore.Mvc;


namespace GymGymACoreApplication.Controllers
{
    public class CategoryTrainerController : Controller
    {
        CategoryTrainerManager ctm = new CategoryTrainerManager(new EfCategoryTrainerRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        TrainerManager tm = new TrainerManager(new EfTrainerRepository());

        public IActionResult Index()
        {
            var categoryTrainer = ctm.CategoryTrainerList();
            return View(categoryTrainer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
            packetCategoryTrainerModel.categoryModel = cm.CategoryList();
            packetCategoryTrainerModel.trainerModel = tm.TrainerList();
            packetCategoryTrainerModel.packetModel = new CategoryTrainer();
            return View(packetCategoryTrainerModel);
        }

        [HttpPost]
        public IActionResult Add(CategoryTrainer categoryTrainer)
        {
            CategoryTrainerValidator categoryTrainerValidator = new CategoryTrainerValidator();
            var result = categoryTrainerValidator.Validate(categoryTrainer);
            if (result.IsValid)
            {
                ctm.CategoryTrainerAdd(categoryTrainer);
                return RedirectToAction("Index");

            }
            else
            {
                PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
                packetCategoryTrainerModel.categoryModel = cm.CategoryList();
                packetCategoryTrainerModel.trainerModel = tm.TrainerList();
                packetCategoryTrainerModel.packetModel = categoryTrainer;
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
            packetCategoryTrainerModel.categoryModel = cm.CategoryList();
            packetCategoryTrainerModel.trainerModel = tm.TrainerList();
            packetCategoryTrainerModel.packetModel = ctm.CategoryTrainerGetById(id);
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
                packetCategoryTrainerModel.categoryModel = cm.CategoryList();
                packetCategoryTrainerModel.trainerModel = tm.TrainerList();
                packetCategoryTrainerModel.packetModel = categoryTrainer;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(packetCategoryTrainerModel);
            }
        }
    }
}
