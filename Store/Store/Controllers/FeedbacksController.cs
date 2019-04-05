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
 
        // GET: Suggestion
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

        // GET: Suggestion/Details/5
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

        // GET: Suggestion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suggestion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CostomerName,CustomerFeedback")] Feedback Feedback)
        {
            if (CreateFeedback(Feedback))
                return RedirectToAction("Index");

            return View(Feedback);
        }

        private bool CreateFeedback(Feedback Feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(Feedback);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        // GET: Suggestion/Edit/5
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

        // POST: Suggestion/Edit/5
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

        // GET: Suggestion/Delete/5
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

        // POST: Suggestion/Delete/5
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
