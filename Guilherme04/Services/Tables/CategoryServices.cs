using Models.Tables;
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

        public Category GetCategoryByID(long iD)
        {
            return categoryDAL.GetCategoryById(iD);
        }

        public void SaveCategory(Category category)
        {
           categoryDAL.SaveCategory(category);
        }

        public Category RemoveCategoryByID(long ID)
        {
            return categoryDAL.RemoveCategorytBy(ID);
        }
    }
}
