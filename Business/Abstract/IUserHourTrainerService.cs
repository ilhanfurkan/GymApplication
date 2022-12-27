using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserHourTrainerService
    {
        void UserHourTrainerAdd(UserHourTrainer userHourTrainer);
        void UserHourTrainerRemove(UserHourTrainer userHourTrainer);
        void UserHourTrainerUpdate(UserHourTrainer userHourTrainer);
        List<UserHourTrainer> UserHourTrainerList();
        UserHourTrainer UserHourTrainerGetById(int id);
        UserHourTrainer UserHourTrainerGetByHour(int hours);
    }
}
