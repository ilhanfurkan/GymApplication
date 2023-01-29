using Entities.Concrete;

namespace GymGymACoreApplication.Models
{
    public class MenuParentModel
    {
        public Menu Menu { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}
