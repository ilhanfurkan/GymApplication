using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1, string searchText="")
        {
            //var category = cm.CategoryList().ToPagedList(page,pageSize);
            //return View(category);
            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<Category> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Categories.Where(usr => usr.CategoryName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Categories.Where(usr => usr.CategoryName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Categories.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Categories.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "Category";
            ViewBag.searchText = searchText;
            return View(data);
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
