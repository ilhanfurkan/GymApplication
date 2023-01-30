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
    public class FooterDetailListComponent : ViewComponent
    {
        FooterDetailManager fdm = new FooterDetailManager(new EfFooterDetailRepository());

        public IViewComponentResult Invoke()
        {
            var footers = fdm.FooterList();
            return View(footers);
        }

    }
}
