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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }
        public void CategoryAdd(Category category)
        {
            categoryDal.Insert(category);
        }

        public Category CategoryGetById(int id)
        {
            return categoryDal.Get(x => x.CategoryId == id);
        }

        public Category CategoryGetByName(string categoryName)
        {
            return categoryDal.Get(x => x.CategoryName == categoryName);
        }

        public List<Category> CategoryList()
        {
            return categoryDal.Listing();
        }

        public void CategoryRemove(Category category)
        {
            categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            categoryDal.Update(category);
        }
    }
}
