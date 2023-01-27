using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace GymGymACoreApplication.ViewComponents
{
    public class TrainerListComponent : ViewComponent
    {
        public readonly Context _context;

        public TrainerListComponent()
        {
            _context = new Context();
        }

        public IViewComponentResult Invoke()
        {
            var trainers = _context.Trainers.ToList();
            return View(trainers);
        }

    }
}
