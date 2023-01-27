using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace GymGymACoreApplication.ViewComponents
{
    public class CategoryListComponent : ViewComponent
    {
        public readonly Context _context;

        public CategoryListComponent()
        {
            _context = new Context();
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

    }
}
