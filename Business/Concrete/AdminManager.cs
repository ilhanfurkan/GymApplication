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
    public class AdminManager : IAdminService
    {
        IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            adminDal.Insert(admin);
        }

        public Admin AdminGetById(int id)
        {
            return adminDal.Get(x => x.AdminId == id);
        }

        public Admin AdminGetByName(string adminName)
        {
            return adminDal.Get(x => x.AdminName == adminName);
        }

        public List<Admin> AdminList()
        {
            return adminDal.Listing();
        }

        public void AdminRemove(Admin admin)
        {
            adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            adminDal.Update(admin);
        }
    }
}
