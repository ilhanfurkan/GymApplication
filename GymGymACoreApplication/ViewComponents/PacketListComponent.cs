using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace GymGymACoreApplication.ViewComponents
{
    public class PacketListComponent : ViewComponent
    {
        public readonly Context _context;

        public PacketListComponent()
        {
            _context = new Context();
        }

        public IViewComponentResult Invoke()
        {
            var packets = _context.Packets.ToList();
            return View(packets);
        }

    }
}
