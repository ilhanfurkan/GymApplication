using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog.Layouts;
using XAct;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using DataAccess.Concrete;
using Context = DataAccess.Concrete.Context;

namespace GymGymACoreApplication.Controllers.İnterfaceController
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        Context c = new Context();
        UserManager um = new UserManager(new EfUserRepository());
        private List<Menu> menuList;
        private TrainerManager tm;
        public HomePageController()
        {
            MenuManager manager = new MenuManager(new EfMenuRepository());
             tm = new TrainerManager(new EfTrainerRepository());
             menuList = manager.MenuList();
        }

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

        //public HomePageController()
        //{
        //    MenuManager manager = new MenuManager(new EfMenuRepository());
        //    var menuList = manager.MenuList();
        //    ViewData["menu"] = menuList;
        //}
        public ActionResult Index()
        {
          
            ViewBag.menu = menuList;
            var listTrainer = tm.TrainerList();
            return View(listTrainer);
        }

        public ActionResult TrainerPage()
        {
            ViewBag.menu = menuList;
            var listTrainer = tm.TrainerList();
            return View(listTrainer);
        }
        public ActionResult AboutPage()
        {
            ViewBag.menu = menuList;
            var listTrainer = tm.TrainerList();
            return View(listTrainer);
        }
        public ActionResult BlogPage()
        {
            ViewBag.menu = menuList;
            return View();
        }
        public ActionResult ContactPage()
        {
            ViewBag.menu = menuList;
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.menu = menuList;
            var user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            ViewBag.menu = menuList;
            um.UserAdd(user);
            return RedirectToAction("Index");
        }


   
    }
}
