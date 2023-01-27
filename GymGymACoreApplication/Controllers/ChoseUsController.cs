using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class ChoseUsController : Controller
    {
        ChoseUsManager cum = new ChoseUsManager(new EfChoseUsRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {
            
            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<ChoseUs> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.ChoseUs.Where(usr => usr.ReasonTitle.Contains(searchText) ||
                usr.ReasonDetail.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();


                itemCounts = c.ChoseUs.Where(usr => usr.ReasonTitle.Contains(searchText) ||
                usr.ReasonDetail.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.ChoseUs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.ChoseUs.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "ChoseUs";
            ViewBag.searchText = searchText;
            return View(data);

        }
        public IActionResult Delete(int id)
        {
            ChoseUs choseUs = cum.ChoseUsGetById(id);
            cum.ChoseUsRemove(choseUs);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ChoseUs choseUs)
        {
            ChoseUsValidator choseUsValidator = new ChoseUsValidator();
            var result = choseUsValidator.Validate(choseUs);
            if (result.IsValid)
            {
                cum.ChoseUsAdd(choseUs);
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
            ChoseUs choseUs = cum.ChoseUsGetById(id);
            return View(choseUs);

        }
        [HttpPost]
        public IActionResult Update(ChoseUs choseUs)
        {
            ChoseUsValidator choseUsValidator = new ChoseUsValidator();
            var result = choseUsValidator.Validate(choseUs);
            if (result.IsValid)
            {
                cum.ChoseUsUpdate(choseUs);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(choseUs);
            }
        }


    }
}
