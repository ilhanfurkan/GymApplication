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
    public class UserCategoryTrainerManager : IUserCategoryTrainerService
    {
        IUserCategoryTrainerDal userCategoryTrainerDal;
        public UserCategoryTrainerManager(IUserCategoryTrainerDal userCategoryTrainerDal)
        {
                this.userCategoryTrainerDal = userCategoryTrainerDal;

        }
        public void UserCategoryTrainerAdd(UserCategoryTrainer userCategoryTrainer)
        {
            userCategoryTrainerDal.Insert(userCategoryTrainer);
        }

        public UserCategoryTrainer UserCategoryTrainerGetById(int id)
        {
            return userCategoryTrainerDal.Get(x => x.RegistrationId == id);
        }

        public UserCategoryTrainer UserCategoryTrainerGetByPacketId(int packetId)
        {
            return userCategoryTrainerDal.Get(x => x.PacketId == packetId);
        }

        public List<UserCategoryTrainer> UserCategoryTrainerList()
        {
            return userCategoryTrainerDal.Listing();
        }

        public void UserCategoryTrainerRemove(UserCategoryTrainer userCategoryTrainer)
        {
            userCategoryTrainerDal.Delete(userCategoryTrainer);
        }

        public void UserCategoryTrainerUpdate(UserCategoryTrainer userCategoryTrainer)
        {
            userCategoryTrainerDal.Update(userCategoryTrainer);
        }
    }
}
