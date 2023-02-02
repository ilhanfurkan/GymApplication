using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;

namespace GymGymACoreApplication.Controllers
{
    public class SliderController : Controller
    {
        SliderManager sm = new SliderManager(new EfSliderRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {

            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<Slider> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Sliders.Where(sm => sm.SliderDetail.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();


                itemCounts = c.Sliders.Where(sm => sm.SliderDetail.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Sliders.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Sliders.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "Slider";
            ViewBag.searchText = searchText;
            return View(data);

        }
        public IActionResult Delete(int id)
        {
            Slider slider = sm.SliderGetById(id);
            sm.SliderRemove(slider);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Slider slider)
        {
            SliderValidator sliderValidator = new SliderValidator();
            var result = sliderValidator.Validate(slider);
            if (result.IsValid)
            {
                sm.SliderAdd(slider);
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
            Slider slider = sm.SliderGetById(id);
            return View(slider);

        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            SliderValidator sliderValidator = new SliderValidator();
            var result = sliderValidator.Validate(slider);
            if (result.IsValid)
            {
                sm.SliderUpdate(slider);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(slider);
            }
        }
    }
    
}
