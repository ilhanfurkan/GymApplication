using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EntityFramework;

namespace GymGymACoreApplication.ViewComponents
{
    public class ChoseUsListComponent : ViewComponent
    {
        ChoseUsManager cum = new ChoseUsManager(new EfChoseUsRepository());

        public IViewComponentResult Invoke()
        {
            var reasons = cum.ChoseUsList();
            return View(reasons);
        }

    }
}
