using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class HourController : Controller
    {

        HourManager hm = new HourManager(new EfHourRepository());
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var hour = hm.HourList().ToPagedList(page, pageSize);
            return View(hour);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Hour hour)
        {
            HourValidator hourValidator = new HourValidator();
            var result = hourValidator.Validate(hour);
            if (result.IsValid)
            {
                hm.HourAdd(hour);
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
            Hour hour = hm.HourGetById(id);
            hour.Deleted = true;
            hm.HourUpdate(hour);
            return RedirectToAction("Index");
        }
        public IActionResult update(int id)
        {
            Hour hour = hm.HourGetById(id);

            return View(hour);
        }
        [HttpPost]
        public IActionResult update(Hour hour)
        {
            HourValidator hourValidator = new HourValidator();
            var result = hourValidator.Validate(hour);
            if (result.IsValid)
            {
                hm.HourUpdate(hour);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(hour);
            }
        }
    }
}
