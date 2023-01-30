using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace GymGymACoreApplication.ViewComponents
{
    public class TrainerListComponent : ViewComponent
    {
        TrainerManager tm = new TrainerManager(new EfTrainerRepository());
        public IViewComponentResult Invoke()
        {
            var trainers = tm.TrainerList();
            return View(trainers);
        }

    }
}
