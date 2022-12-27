using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserHourTrainerManager : IUserHourTrainerService
    {
        IUserHourTrainerDal userHourTrainerDal;
        public UserHourTrainerManager(IUserHourTrainerDal userHourTrainerDal)
        {
            this.userHourTrainerDal = userHourTrainerDal;
        }
        public void UserHourTrainerAdd(UserHourTrainer userHourTrainer)
        {
            userHourTrainerDal.Insert(userHourTrainer);
        }

        public UserHourTrainer UserHourTrainerGetByHour(int hours)
        {
            return userHourTrainerDal.Get(x => x.Hours == hours);
        }

        public UserHourTrainer UserHourTrainerGetById(int id)
        {
            return userHourTrainerDal.Get(x => x.AppointmentId == id);
        }

        public List<UserHourTrainer> UserHourTrainerList()
        {
            return userHourTrainerDal.Listing();
        }

        public void UserHourTrainerRemove(UserHourTrainer userHourTrainer)
        {
            userHourTrainerDal.Delete(userHourTrainer);
        }


        public void UserHourTrainerUpdate(UserHourTrainer userHourTrainer)
        {
            userHourTrainerDal.Update(userHourTrainer);
        }
    }
}
