using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using GymGymACoreApplication.Models;
using GymGymACoreApplication.PagedList;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GymGymACoreApplication.Controllers
{
    public class CategoryTrainerController : Controller
    {
        CategoryTrainerManager ctm = new CategoryTrainerManager(new EfCategoryTrainerRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        TrainerManager tm = new TrainerManager(new EfTrainerRepository());

        public IActionResult Index(int page = 1, string searchText="")
        {
            //var categoryTrainer = ctm.CategoryTrainerList().ToPagedList(page,pageSize);
            //return View(categoryTrainer);
            int pageSize = 5;
            Context c = new Context();
            Pager pager;
            List<CategoryTrainer> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Packets.Where(usr => usr.PacketName.Contains(searchText) ||
                usr.PacketDetail.Contains(searchText) ||
                usr.PacketPrice.Contains(searchText) ||
                usr.Trainer.TrainerFirstName.Contains(searchText) ||
                usr.ActivePassive.ToString().Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Packets.Where(usr => usr.PacketName.Contains(searchText) ||
                usr.PacketDetail.Contains(searchText) ||
                usr.PacketPrice.Contains(searchText) ||
                usr.Trainer.TrainerFirstName.Contains(searchText) ||
                usr.ActivePassive.ToString().Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Packets.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Packets.ToList().Count;
            }
            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "Index";
            ViewBag.contrName = "CategoryTrainer";
            ViewBag.searchText = searchText;
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
            packetCategoryTrainerModel.Categories = cm.CategoryList();
            packetCategoryTrainerModel.Trainers = tm.TrainerList();
            packetCategoryTrainerModel.CategoryTrainer = new CategoryTrainer();
            return View(packetCategoryTrainerModel);
        }

        [HttpPost]
        public IActionResult Add(CategoryTrainer categoryTrainer)
        {
            PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
            packetCategoryTrainerModel.Categories = cm.CategoryList();
            packetCategoryTrainerModel.Trainers = tm.TrainerList();
            packetCategoryTrainerModel.CategoryTrainer = categoryTrainer;
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
                return View(packetCategoryTrainerModel);
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
            PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
            packetCategoryTrainerModel.Categories = cm.CategoryList();
            packetCategoryTrainerModel.Trainers = tm.TrainerList();
            packetCategoryTrainerModel.CategoryTrainer = ctm.CategoryTrainerGetById(id);
            return View(packetCategoryTrainerModel);
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
                PacketCategoryTrainerModel packetCategoryTrainerModel = new PacketCategoryTrainerModel();
                packetCategoryTrainerModel.Categories = cm.CategoryList();
                packetCategoryTrainerModel.Trainers = tm.TrainerList();
                packetCategoryTrainerModel.CategoryTrainer = categoryTrainer;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(packetCategoryTrainerModel);
            }
        }
    }
}
