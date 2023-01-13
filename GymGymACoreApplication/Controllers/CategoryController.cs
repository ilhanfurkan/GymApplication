using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var category = cm.CategoryList().ToPagedList(page,pageSize);
            return View(category);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoryValidator categoryValidator= new CategoryValidator();
            var result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                cm.CategoryAdd(category);
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

        public IActionResult Delete(int id)
        {
            Category category = cm.CategoryGetById(id);
            category.Deleted = true;
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
        public IActionResult update(int id)
        {
            Category category =cm.CategoryGetById(id);

            return View(category);
        }
        [HttpPost]
        public IActionResult update(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            var result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                cm.CategoryUpdate(category);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(category);
            }

        }
    }
}
