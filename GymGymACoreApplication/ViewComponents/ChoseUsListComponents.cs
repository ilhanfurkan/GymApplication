using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace GymGymACoreApplication.ViewComponents
{
    public class ChoseUsListComponent : ViewComponent
    {
        public readonly Context _context;

        public ChoseUsListComponent()
        {
            _context = new Context();
        }

        public IViewComponentResult Invoke()
        {
            var reasons = _context.ChoseUs.ToList();
            return View(reasons);
        }

    }
}
