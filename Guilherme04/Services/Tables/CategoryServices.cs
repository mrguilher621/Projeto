using Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.DAL.Tables;

namespace Services.Tables
{
   public  class CategoryServices
    {
        private CategoryDAL categoryDAL = new CategoryDAL();

        public IQueryable<Category> GetCategoriesClassifiedByName()

        {

            return categoryDAL.GetCategoriesClassifiedByName();

        }

        public Category GetCategoryById(long id)
        {
            return categoryDAL.GetCategoryById(id);
        }

        public void SaveCategory(Category category)
        {
           categoryDAL.SaveCategory(category);
        }

        public Category RemoveCategoryById(long id)
        {
            return categoryDAL.RemoveCategorytBy(id);
        }
    }
}
