using Models.Tables;
using Services.Tables;
using System.Net;
using System.Web.Mvc;

namespace Guilherme04.Areas.Tables.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryServices categoryServices = new CategoryServices();

        private ActionResult GetViewCategoryById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryServices.GetCategoryByID((long)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        private ActionResult SaveCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryServices.SaveCategory(category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }

        private void PopularViewBag(Category category = null)
        {
            if (category == null)
            {
                ViewBag.CategoryId = new SelectList(categoryServices.GetCategoriesClassifiedByName(),
                   "CategoryId", "Name");
            }
        }

                #region [ Actions ]

        #region [ Index ]
                // GET: Categories
                public ActionResult Index()
        {
            return View(categoryServices.GetCategoriesClassifiedByName());
        }

        #endregion [ Index ]

        #region [ Create ]
        // GET: Category
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            
            return SaveCategory(category);
        }


        #endregion [ Create  ]

        #region [ Edit ]

        // GET: EditCategory
        public ActionResult Edit(long? ID)
        {
            PopularViewBag(categoryServices.GetCategoryByID((long)ID));
            return GetViewCategoryById(ID);
        }

        //POST: Categories/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            return SaveCategory(category);
        }
        #endregion [ Edit ]

        #region [ Delete ]
        public ActionResult Delete(long? ID)
        {
            return GetViewCategoryById(ID);
        }
        //POST: Categories/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long ID)
        {
            Category category = categoryServices.RemoveCategoryByID(ID);
            TempData["Message"] = "Category" + category.Name.ToUpper() + "Was Removed";
            return RedirectToAction("Index");
        }

        #endregion [ Delete ]

        #region [ Detais ]
          public ActionResult Details(long? ID)
        {

            return GetViewCategoryById(ID);
        }

        #endregion [ Detais ]

        #endregion [ Actoins ]

       

       
   
      
    }
}