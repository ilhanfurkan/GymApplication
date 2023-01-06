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
    public class CategoryTrainerManager : ICategoryTrainerService
    {
        ICategoryTrainerDal categoryTrainerDal;
        public CategoryTrainerManager(ICategoryTrainerDal categoryTrainerDal)
        {
            this.categoryTrainerDal = categoryTrainerDal;
        }

        public void CategoryTrainerAdd(CategoryTrainer categoryTrainer)
        {
            categoryTrainerDal.Insert(categoryTrainer);
        }

        public CategoryTrainer CategoryTrainerGetById(int id)
        {
            return categoryTrainerDal.Get(x => x.PacketId == id);
        }

        public CategoryTrainer CategoryTrainerGetByName(string packetName)
        {
            return categoryTrainerDal.Get(x => x.PacketName == packetName);
        }

        public List<CategoryTrainer> CategoryTrainerList()
        {
            return categoryTrainerDal.Listing();
        }

        public void CategoryTrainerRemove(CategoryTrainer categoryTrainer)
        {
             categoryTrainerDal.Delete(categoryTrainer);
        }

        public void CategoryTrainerUpdate(CategoryTrainer categoryTrainer)
        {
            categoryTrainerDal.Update(categoryTrainer);
        }
    }
}
