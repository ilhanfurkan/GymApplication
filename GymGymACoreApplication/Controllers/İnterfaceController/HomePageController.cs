using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog.Layouts;
using XAct;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace GymGymACoreApplication.Controllers.İnterfaceController
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {

        //public string Layout { get; }

        //public HomePageController(Admin admin)
        //{
        //    if (User.IsInRole("Admin"))
        //    {
        //        Layout = "_AdminLayout";
        //    }
        //    else
        //    {
        //        Layout = "_HomePageLayout";
        //    }
        //}
        // GET: HomePageController
      
    
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomePageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomePageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomePageController/Create
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

        // GET: HomePageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomePageController/Edit/5
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

        // GET: HomePageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomePageController/Delete/5
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
