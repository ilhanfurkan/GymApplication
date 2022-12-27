using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void CategoryAdd(Category category);
        void CategoryRemove(Category category);
        void CategoryUpdate(Category category);
        List<Category> CategoryList();
        Category CategoryGetById(int id);
        Category CategoryGetByName(string categoryName);
    }
}
