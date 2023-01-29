using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MenuManager : IMenuService
    {
        IMenuDal menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            this.menuDal = menuDal;
        }

        public void MenuAdd(Menu menu)
        {
            menuDal.Insert(menu);
        }

        public Menu MenuGetById(int id)
        {
            return menuDal.Get(x=>x.MenuId == id);
        }

        public Menu MenuGetBySeoUrl(string seoUrl)
        {
            return menuDal.Get(x => x.SeoUrl == seoUrl);
        }

        public List<Menu> MenuList()
        {
            return menuDal.Listing();
        }

        public void MenuRemove(Menu menu)
        {
            menuDal.Delete(menu);
        }

        public void MenuUpdate(Menu menu)
        {
            menuDal.Update(menu);
        }
    }
}
