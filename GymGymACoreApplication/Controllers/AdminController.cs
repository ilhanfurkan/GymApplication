using Business.Concrete;
using Business.Validations;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;
using X.PagedList;
using NLog.Layouts;
using XAct.Users;

namespace GymGymACoreApplication.Controllers
{
    
    public class AdminController : Controller
    {
        
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        private readonly ILogger<AdminController> _logger;
        private readonly IToastNotification _toastNotification;
        public AdminController(ILogger<AdminController> logger, IToastNotification toastNotification)
        {
         
            _logger = logger;
            _toastNotification = toastNotification;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult login()
        {
            return View();

        }

        public IActionResult profile()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Entry(Admin admin)
        {
          
                Context context = new Context();
                var result = context.Admins.Where(x => x.Mail == admin.Mail && x.AdminPassword == admin.AdminPassword).SingleOrDefault();
                if (result != null)
                {

                    var claims = new List<Claim> { new Claim(ClaimTypes.Email, result.Mail), new Claim(ClaimTypes.Name, result.AdminName) };

                    var userIdentify = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentify);
                    //  await HttpContext.SignInAsync(principal);
                    await HttpContext
                        .SignInAsync(
                        principal,
                        new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(10) });
                    return RedirectToAction("Index", "Admin");

                }
                _toastNotification.AddErrorToastMessage("User Name And Password Are Wrong");
                TempData["init"] = 1;
                return RedirectToAction("login");
            
          
            
        }
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("login");

        }
        //public string sifreleme(string value)
        //{
        //    MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        //    byte[] dizi = Encoding.UTF8.GetBytes(value);
        //    dizi = provider.ComputeHash(dizi);
        //    StringBuilder stringBuilder = new StringBuilder();
        //    foreach (byte bayt in dizi)
        //    {
        //        stringBuilder.Append(bayt.ToString().ToLower());
        //    }
        //    return stringBuilder.ToString();
        //}

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 5)
        {

            var admin = adminManager.AdminList().ToPagedList(page, pageSize);
            return View(admin);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            var result = adminValidator.Validate(admin);
            if (result.IsValid)
            {
                adminManager.AdminAdd(admin);
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
        public IActionResult Delete(int id)
        {
            Admin admin = adminManager.AdminGetById(id);
            admin.Deleted = true;
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Admin admin = adminManager.AdminGetById(id);

            return View(admin);
        }
        [HttpPost]
        public IActionResult Update(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            var result = adminValidator.Validate(admin);
            if (result.IsValid)
            {
                adminManager.AdminUpdate(admin);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(admin);
            }

        }
    }
}
