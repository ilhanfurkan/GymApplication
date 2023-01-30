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
    public class FooterDetailController : Controller
    {
        FooterDetailManager fdm = new FooterDetailManager(new EfFooterDetailRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {

            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<FooterDetail> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.FooterDetails.Where(usr => usr.TipsTitle.Contains(searchText) ||
                usr.TipsDetail.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();


                itemCounts = c.FooterDetails.Where(usr => usr.TipsTitle.Contains(searchText) ||
                usr.TipsDetail.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.FooterDetails.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.FooterDetails.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "FooterDetail";
            ViewBag.searchText = searchText;
            return View(data);

        }
        public IActionResult Delete(int id)
        {
            FooterDetail footerDetail = fdm.FooterGetById(id);
            fdm.FooterRemove(footerDetail);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FooterDetail footerDetail)
        {
            FooterDetailValidator footerDetailValidator = new FooterDetailValidator();
            var result = footerDetailValidator.Validate(footerDetail);
            if (result.IsValid)
            {
                fdm.FooterAdd(footerDetail);
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
            FooterDetail footerDetail = fdm.FooterGetById(id);
            return View(footerDetail);

        }
        [HttpPost]
        public IActionResult Update(FooterDetail footerDetail)
        {
            FooterDetailValidator footerDetailValidator = new FooterDetailValidator();
            var result = footerDetailValidator.Validate(footerDetail);
            if (result.IsValid)
            {
                fdm.FooterUpdate(footerDetail);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(footerDetail);
            }
        }


    }
}
