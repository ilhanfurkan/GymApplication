using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GymGymACoreApplication.Controllers
{

    public class TrainerController : Controller
    {
        TrainerManager tm = new TrainerManager(new EfTrainerRepository());

        // GET: TrainerController
        public ActionResult Index()
        {
            var trainer = tm.TrainerList();
            return View(trainer);
        }

        // GET: TrainerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrainerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrainerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrainerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
