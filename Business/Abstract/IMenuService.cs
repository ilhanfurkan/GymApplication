using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMenuService
    {
        List<Menu> MenuList();
        void MenuAdd(Menu menu);
        void MenuUpdate(Menu menu);
        Menu MenuGetById(int id);
        Menu MenuGetBySeoUrl(String seoUrl);
    }
}
