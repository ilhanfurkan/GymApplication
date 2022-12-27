using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITrainerService
    {
        void TrainerAdd(Trainer trainer);
        void TrainerRemove(Trainer trainer);
        void TrainerUpdate(Trainer trainer);
        List<Trainer> TrainerList();
        Trainer TrainerGetById(int id);
        Trainer TrainerGetByName(string firstname);
    }
}
