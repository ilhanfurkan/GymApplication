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
            throw new NotImplementedException();
        }

        public Menu MenuGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Menu MenuGetBySeoUrl(string seoUrl)
        {
            throw new NotImplementedException();
        }

        public List<Menu> MenuList()
        {
            return menuDal.Listing();
        }

        public void MenuUpdate(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
