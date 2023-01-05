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
    public class HourTrainerManager : IHourTrainerService
    {
        IHourTrainerDal hourTrainerDal;
        public HourTrainerManager(IHourTrainerDal hourTrainerDal)
        {
            this.hourTrainerDal = hourTrainerDal;
        }

        public void HourTrainerAdd(HourTrainer hourTrainer)
        {
            hourTrainerDal.Insert(hourTrainer);
        }

        public HourTrainer HourTrainerGetById(int id)
        {
            return hourTrainerDal.Get(x => x.SeanceId == id);
        }

        public List<HourTrainer> HourTrainerList()
        {
            return hourTrainerDal.Listing();
        }

        public void HourTrainerRemove(HourTrainer hourTrainer)
        {
            hourTrainerDal.Delete(hourTrainer);
        }

        public void HourTrainerUpdate(HourTrainer hourTrainer)
        {
            hourTrainerDal.Update(hourTrainer);
        }
    }
}
