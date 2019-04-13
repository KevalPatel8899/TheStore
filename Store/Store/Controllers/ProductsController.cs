using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Store.Models;
using Store.Models.BL;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        //private StoreContext db = new StoreContext();
        IProduct db;


        public ProductsController()
        {
            this.db = new ProductBL();
        }

        public ProductsController(IProduct db)
        {
            this.db = db;

        }
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.CategoryName);
            return View("Index", products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            Product product = db.Products.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("Details",product);
        }

        // GET: Products/Create    
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View("Create");
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,CategoryId,Description,ProductName,Price,ProductPhoto")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Products.Add(product);
                //db.SaveChanges();
                db.Save(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View("Create", product);
        }

        // GET: Products/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            Product product = db.Products.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View("Edit",product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,CategoryId,Description,ProductName,Price,ProductPhoto")] Product product)
        {
            if (ModelState.IsValid)
            {

                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View("Edit",product);
        }

        // GET: Products/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.SingleOrDefault(p => p.ProductId == id);
            //Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View("Delete",product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.Products.Find(id);
            Product product = db.Products.SingleOrDefault(p => p.ProductId == id);
            //db.Products.Remove(product);
            //db.SaveChanges();
            db.Delete(product);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
