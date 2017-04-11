using Guilherme04.Contexts;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Guilherme04.Models;
using System.Net;

namespace Guilherme04.Controllers
{
    public class ProductsController : Controller
    {

      #region [ Actions ]

        #region [ Index ]
        private EFContext context = new EFContext();
       

        // GET: Products
        public ActionResult Index()
        {
            var products = context.Products.Include(c => c.Category).Include(s => s.Supplier).OrderBy(n => n.Name);
            return View(products);
        }

        #endregion [ Index ]

      #region [ Details ]

        // GET: Products/Details/5
        public ActionResult Details(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId == id).Include(c => c.Category).
                Include(s => s.Supplier).First();
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        #endregion [ Details ]

      #region [ Create ]

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories.
                OrderBy(b => b.Name), "CategoryId", "Name");
            ViewBag.SupplierId = new SelectList(context.Suppliers.
                OrderBy(b => b.Name), "SupplierId", "Name");
            return View();
        }
        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }

        #endregion [ Create ]

      #region [ Edit ]
        // GET: Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null){

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(b => b.Name),
                "CategoryId", "Name", product.CategoryId);
            ViewBag.SupplierId = new SelectList(context.Suppliers.OrderBy(b => b.Name),
               "SupplierId", "Name", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(long? id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        #endregion [ Edit ]

      #region [ Delete ]

        // GET: Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId == id).Include(c => c.Category).
                Include(s => s.Supplier).First();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(long? id, Product product)
        {
            try
            {
                product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                TempData["Massege"] ="Product" + product.Name.ToUpper() + "Was Removed";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion [ Delete ]

        #endregion [ Actions ]
    }
}
