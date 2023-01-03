using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace GymGymACoreApplication.Controllers
{
    public class CategoryTrainerController : Controller
    {
        CategoryTrainerManager ctm = new CategoryTrainerManager(new EfCategoryTrainerRepository());

        public IActionResult Index()
        {
            var categoryTrainer = ctm.CategoryTrainerList();
            return View(categoryTrainer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
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
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
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
            CategoryTrainer categoryTrainer = ctm.CategoryTrainerGetById(id);

            return View(categoryTrainer);
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
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(categoryTrainer);
            }
        }
    }
}
