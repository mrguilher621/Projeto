using Guilherme04.Contexts;
using Guilherme04.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Guilherme04.ExtensionMethods;

namespace Guilherme04.Controllers
{
    public class SuppleirsController : Controller
    {
        private EFContext context = new EFContext();

        #region [ Action ]


        #region [ Index ]
        // GET: Suppleirs
        // GET: Suppliers/Index
        public ActionResult Index()
        {
            return View(context.Suppliers.OrderBy(supplier => supplier.Name));
        }

        #endregion [ Index ]

        #region [ Details ]
        // GET: Suppliers/Detais/5
        public ActionResult Details(long? ID)
        {
            if(ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = context.Suppliers.Find(ID);
            if (supplier == null)
            {

                return HttpNotFound();
            }

            return View(supplier);
        }

        #endregion [ Details ] 

        #region [ Create ]
        public ActionResult Create()
        {
            return View();

        }
        //POST: Suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion [ Create ]

        #region [ Edit ]
        // GET: Suppliers/Edit/5
        public ActionResult Edit(long? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = context.Suppliers.Find(ID);

            if (supplier == null)
            {
                return HttpNotFound();
            }

            return View(supplier);
        }

        //POST: Suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var dbEntityEntry = context.Entry(supplier);
                dbEntityEntry.State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(supplier);
        }

        #endregion  [ Edit ]

        #region [ Delete ]
        public ActionResult Delete(long? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = context.Suppliers.Find(ID);

            if (supplier == null)
            {
                return HttpNotFound();
            }

            return View(supplier);
        }
        //POST: Suppliers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Delete(long ID)
        {
            Supplier supplier = context.Suppliers.Find(ID);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion [ Delete ]

        #endregion [ Action ]


    }
}
