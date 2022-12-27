using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryTrainerService
    {
        void CategoryTrainerAdd(CategoryTrainer categoryTrainer);
        void CategoryTrainerRemove(CategoryTrainer categoryTrainer);
        void CategoryTrainerUpdate(CategoryTrainer categoryTrainer);
        List<CategoryTrainer> CategoryTrainerList();
        CategoryTrainer CategoryTrainerGetById(int id);
        CategoryTrainer CategoryTrainerGetByName(string packetName);
    }
}
