using Guilherme04.Contexts;
using Guilherme04.ExtensionMethods;
using Guilherme04.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Guilherme04.Controllers
{
    public class CategoriesController : Controller
    {
        private EFContext context = new EFContext();

        #region [ Actions ]

        #region [ Index ]
        // GET: Categories
        public ActionResult Index()
        {
            return View(context.Categories.OrderBy(c=> c.name));
        }

        #endregion [ Index ]

        #region [ Create ]
        // GET: Category
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            //category.categoryID = categories.Select(c => c.categoryID).Max() + 1;

           context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        #endregion [ Create  ]

        #region [ Edit ]

        // GET: EditCategory
        public ActionResult Edit(long? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = context.Categories.Find(ID);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        //POST: Categories/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dbEntityEntry = context.Entry(category);
                dbEntityEntry.State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(category);
        }
        #endregion [ Edit ]

        #region [ Delete ]
        public ActionResult Delete(long? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = context.Categories.Find(ID);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }
        //POST: Categories/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long ID)
        {
            Category category = context.Categories.Find(ID);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion [ Delete ]

        #region [ Detais ]
          public ActionResult Details(long? ID)
        {
            if(ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = context.Categories.Find(ID);
            if (category == null)
            {

                return HttpNotFound();
            }

            return View(category);
        }

        #endregion [ Detais ]

        #endregion [ Actoins ]

       

       
   
      
    }
}