using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHourTrainerService
    {
        void HourTrainerAdd(HourTrainer hourTrainer);
        void HourTrainerRemove(HourTrainer hourTrainer);
        void HourTrainerUpdate(HourTrainer hourTrainer);
        List<HourTrainer> HourTrainerList();
        HourTrainer HourTrainerGetById(int id);
    }
}
