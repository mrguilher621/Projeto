﻿using Model.Tables;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL.Tables
{
  public  class CategoryDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Category>GetCategoriesClassifiedByName()
        {
            return context.Categories.OrderBy(b => b.Name);
        }

        public void SaveCategory(Category category)

        {

            if (category.CategoryID == null)
            {
                context.Categories.Add(category);
            }
            else
            {
                context.Entry(category).State = EntityState.Modified;
            }

            context.SaveChanges();

        }

        public Category RemoveCategorytBy(long id)

        {
            Category category = GetCategoryById(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return category;

        }

        public Category GetCategoryById(long id)
        {
            return context.Categories.Where(c => c.CategoryID == id).First();
        }
    }
}
