using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using GymGymACoreApplication.Models;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class MenuController : Controller
    {
        MenuManager mm = new MenuManager(new EfMenuRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {

            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<Menu> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Menus.Where(usr => usr.MenuName.Contains(searchText) ||
                usr.SeoUrl.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();


                itemCounts = c.Menus.Where(usr => usr.MenuName.Contains(searchText) ||
                usr.SeoUrl.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Menus.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Menus.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "Menu";
            ViewBag.searchText = searchText;
            return View(data);

        }
        public IActionResult Delete(int id)
        {
            Menu menu = mm.MenuGetById(id);
            menu.Deleted = true;
            mm.MenuUpdate(menu);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            var menuList = mm.MenuList();
            MenuParentModel menuParentModel = new MenuParentModel();
            menuParentModel.Menus = menuList;
            menuParentModel.Menu = new Menu();
            return View(menuParentModel);
        }

        [HttpPost]
        public IActionResult Add(Menu menu)
        {
            MenuValidator menuValidator = new MenuValidator();
            var result = menuValidator.Validate(menu);
            if (result.IsValid)
            {
                mm.MenuAdd(menu);
                return RedirectToAction("Index");

            }
            else
            {
                var menuList = mm.MenuList();
                MenuParentModel menuParentModel = new MenuParentModel();
                menuParentModel.Menus = menuList;
                menuParentModel.Menu = menu;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(menuParentModel);
            }

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            MenuParentModel menuParentModel = new MenuParentModel();
            menuParentModel.Menus = mm.MenuList();
            menuParentModel.Menu = mm.MenuGetById(id);
            return View(menuParentModel);

        }
        [HttpPost]
        public IActionResult Update(Menu menu)
        {
            MenuValidator menuValidator = new MenuValidator();
            var result = menuValidator.Validate(menu);
            if (result.IsValid)
            {
                mm.MenuUpdate(menu);
                return RedirectToAction("Index");

            }
            else
            {
                MenuParentModel menuParentModel = new MenuParentModel();
                menuParentModel.Menus = mm.MenuList();
                menuParentModel.Menu = menu;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(menuParentModel);
            }
        }


    }
}






//                    PAGİNG AND SEARCHİNG PART

