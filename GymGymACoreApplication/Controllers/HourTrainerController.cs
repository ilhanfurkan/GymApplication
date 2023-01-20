using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using GymGymACoreApplication.Models;
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
		public IActionResult Index(int page = 1, int pageSize = 1)
		{
			var hourTrainer = htm.HourTrainerList().ToPagedList(page, pageSize);
			return View(hourTrainer);
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
