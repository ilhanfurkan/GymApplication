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
    public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public void UserAdd(User user)
        {
            userDal.Insert(user);
        }

        public User UserGetById(int id)
        {
            return userDal.Get(x => x.UserId == id);
        }

        public User UserGetByName(string firstname)
        {
            return userDal.Get(x => x.FirstName == firstname);
        }

        public List<User> UserList()
        {
            return userDal.Listing();
        }

        public void UserRemove(User user)
        {
            userDal.Delete(user);
        }

        public void UserUpdate(User user)
        {
            userDal.Update(user);
        }
    }
}
