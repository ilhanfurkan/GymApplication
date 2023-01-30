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
    public class PacketListComponent : ViewComponent
    {
        CategoryTrainerManager ctm = new CategoryTrainerManager(new EfCategoryTrainerRepository());

        public IViewComponentResult Invoke()
        {
            var packets = ctm.CategoryTrainerList();
            return View(packets);
        }

    }
}
