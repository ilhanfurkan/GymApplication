using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using GymGymACoreApplication.Models;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class HourTrainerController : Controller
    {
		HourManager hm = new HourManager(new EfHourRepository());
		TrainerManager tm = new TrainerManager(new EfTrainerRepository());
        HourTrainerManager htm = new HourTrainerManager(new EfHourTrainerRepository());
		public IActionResult Index(int page = 1,string searchText="")
		{
            //var hourTrainer = htm.HourTrainerList().ToPagedList(page, pageSize);
            //return View(hourTrainer);
            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<HourTrainer> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Seances.Where(usr => usr.trainer.TrainerFirstName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Seances.Where(usr => usr.trainer.TrainerFirstName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Seances.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Seances.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "HourTrainer";
            ViewBag.searchText = searchText;
            return View(data);
        }

		[HttpGet]
		public IActionResult Add()
		{
			SeanceHourTrainerModel seanceHourTrainerModel = new SeanceHourTrainerModel();
			seanceHourTrainerModel.Hours = hm.HourList();
			seanceHourTrainerModel.Trainers = tm.TrainerList();
			seanceHourTrainerModel.HourTrainer = new HourTrainer();
			return View(seanceHourTrainerModel);
		}

		[HttpPost]
		public IActionResult Add(HourTrainer hourTrainer)
		{
			HourTrainerValidator hourTrainerValidator = new HourTrainerValidator();
			var result = hourTrainerValidator.Validate(hourTrainer);
			if (result.IsValid)
			{
				htm.HourTrainerAdd(hourTrainer);
				return RedirectToAction("Index");

			}
			else
			
			{
                    SeanceHourTrainerModel seanceHourTrainerModel = new SeanceHourTrainerModel();
                    seanceHourTrainerModel.Hours = hm.HourList();
                    seanceHourTrainerModel.Trainers = tm.TrainerList();
					seanceHourTrainerModel.HourTrainer = hourTrainer;
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View(seanceHourTrainerModel);
            }

		}
		public IActionResult delete(int id)
		{
			HourTrainer hourTrainer = htm.HourTrainerGetById(id);
			hourTrainer.Deleted = true;
			htm.HourTrainerUpdate(hourTrainer);
			return RedirectToAction("Index");
		}
		public IActionResult update(int id)
		{
            SeanceHourTrainerModel seanceHourTrainerModel = new SeanceHourTrainerModel();
            seanceHourTrainerModel.Hours = hm.HourList();
            seanceHourTrainerModel.Trainers = tm.TrainerList();
			seanceHourTrainerModel.HourTrainer = htm.HourTrainerGetById(id);
            return View(seanceHourTrainerModel);
        }
		[HttpPost]
		public IActionResult update(HourTrainer hourTrainer)
		{
			HourTrainerValidator hourTrainerValidator = new HourTrainerValidator();
			var result = hourTrainerValidator.Validate(hourTrainer);
			if (result.IsValid)
			{
				htm.HourTrainerUpdate(hourTrainer);
				return RedirectToAction("Index");

			}
			else
			{
                SeanceHourTrainerModel seanceHourTrainerModel = new SeanceHourTrainerModel();
                seanceHourTrainerModel.Hours = hm.HourList();
                seanceHourTrainerModel.Trainers = tm.TrainerList();
                seanceHourTrainerModel.HourTrainer = hourTrainer;
                foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View(seanceHourTrainerModel);
			}
		}
	}
}
