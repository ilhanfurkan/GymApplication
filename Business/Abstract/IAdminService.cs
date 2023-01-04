using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        void AdminAdd(Admin admin);
        void AdminRemove(Admin admin);
        void AdminUpdate(Admin admin);
        List<Admin> AdminList();
        Admin AdminGetById(int id);
        Admin AdminGetByName(string adminName);
    }
}
