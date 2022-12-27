using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void UserAdd(User user);
        void UserRemove(User user);
        void UserUpdate(User user);
        List<User> UserList();
        User UserGetById(int id);
        User UserGetByName(string firstname);
    }
}
