﻿using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace GymGymACoreApplication.ViewComponents
{
    public class CategoryListComponent : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var categories = cm.CategoryList();
            return View(categories);
        }

    }
}
