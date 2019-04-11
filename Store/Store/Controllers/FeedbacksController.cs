using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class FeedbacksController : Controller
    {
        private StoreContext db = new StoreContext();
 
        // GET: Feedback
        public ActionResult Index()
        {
            FeedbackList c1 = new FeedbackList();
            c1.Feedback = (db.Feedbacks.ToList());

            return View(c1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "CustomerId, CustomerName, CustomerFeedback")] Feedback newCustomer)
        {
            ModelState.Clear();
            FeedbackList cl = new FeedbackList();
            cl.newCustomers = new Feedback { CustomerName = "", CustomerFeedback = "" };
            if (!CreateFeedback(newCustomer))
            {
                cl.newCustomers = newCustomer;
            }

            cl.Feedback = db.Feedbacks.ToList();


            return PartialView(cl);
        }

        // GET: Feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback Feedback = db.Feedbacks.Find(id);
            if (Feedback == null)
            {
                return HttpNotFound();
            }
            return View(Feedback);
        }

        // GET: Feedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerName,CustomerFeedback")] Feedback newCustomers)
        {
            if (CreateFeedback(newCustomers))
                return RedirectToAction("Index");

            return PartialView(newCustomers);
        }

        private bool CreateFeedback(Feedback newCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(newCustomer);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        // GET: Feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback Feedback = db.Feedbacks.Find(id);
            if (Feedback == null)
            {
                return HttpNotFound();
            }
            return View(Feedback);
        }

        // POST: Feedback/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerName,CustomerFeedback")] Feedback Feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Feedback);
        }

        // GET: Feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback Feedback = db.Feedbacks.Find(id);
            if (Feedback == null)
            {
                return HttpNotFound();
            }
            return View(Feedback);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback Feedback= db.Feedbacks.Find(id);
            db.Feedbacks.Remove(Feedback);
            db.SaveChanges();
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
