using Models.Register;
using Services.Register;
using System.Net;
using System.Web.Mvc;

namespace Guilherme04.Areas.Register.Controllers
{
    public class SuppliersController : Controller
    {
        private SupplierServices supplierServices = new SupplierServices();

        private ActionResult GetViewSupplierById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = supplierServices.GetSupplierById((long)id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        private ActionResult SaveSupplier(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    supplierServices.SaveSupplier(supplier);
                    return RedirectToAction("Index");
                }
                return View(supplier);
            }
            catch
            {
                return View(supplier);
            }
        }

        private void PopularViewBag(Supplier supplier = null)
        {
            if (supplier == null)
            {
                ViewBag.SupplierId = new SelectList(supplierServices.GetSuppliersClassifiedsByName(),
                   "SupplierId", "Name");
            }
        }


        #region [ Action ]


        #region [ Index ]
        // GET: Suppleirs
        // GET: Suppliers/Index
        public ActionResult Index()
        {
            return View(supplierServices.GetSuppliersClassifiedsByName());
        }

        #endregion [ Index ]

        #region [ Details ]
        // GET: Suppliers/Detais/5
        public ActionResult Details(long? ID)
        {

            return GetViewSupplierById(ID);
        }

        #endregion [ Details ] 

        #region [ Create ]
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }
        //POST: Suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            return SaveSupplier(supplier);
        }
        #endregion [ Create ]

        #region [ Edit ]
        // GET: Suppliers/Edit/5
        public ActionResult Edit(long? ID)
        {
            PopularViewBag(supplierServices.GetSupplierById((long)ID));
            return GetViewSupplierById(ID);
        }

        //POST: Suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {

            return SaveSupplier(supplier);
        }

        #endregion  [ Edit ]

        #region [ Delete ]
        public ActionResult Delete(long? ID)
        { 
            return GetViewSupplierById(ID);
        }
        //POST: Suppliers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Delete(long ID)
        {
            Supplier supplier = supplierServices.RemoveSupplierById(ID);
            TempData["Message"] = "Supplier" + supplier.Name.ToUpper() + "Was Removed";
            return RedirectToAction("Index");
        }
        #endregion [ Delete ]

        #endregion [ Action ]


    }
}
