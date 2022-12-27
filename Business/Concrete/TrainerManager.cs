using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TrainerManager : ITrainerService
    {
        ITrainerDal trainerDal;
        public TrainerManager(ITrainerDal trainerDal)
        {
            this.trainerDal=trainerDal;
        }
        public void TrainerAdd(Trainer trainer)
        {
            trainerDal.Insert(trainer);
        }

        public Trainer TrainerGetById(int id)
        {
            return trainerDal.Get(x => x.TrainerId == id);
        }

        public Trainer TrainerGetByName(string firstname)
        {
            return trainerDal.Get(x => x.TrainerFirstName == firstname);
        }

        public List<Trainer> TrainerList()
        {
            return trainerDal.Listing();
        }

        public void TrainerRemove(Trainer trainer)
        {
            trainerDal.Delete(trainer);
        }

        public void TrainerUpdate(Trainer trainer)
        {
            trainerDal.Update(trainer);
        }
    }
}
