using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using varastonhallinta1.Models;

namespace varastonhallinta1.Controllers
{
    public class RoolitController : Controller
    {
        private naytto1Entities1 db = new naytto1Entities1();

        // GET: Roolit
        public ActionResult Index()
        {
            return View(db.Roolit.ToList());
        }

        // GET: Roolit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roolit roolit = db.Roolit.Find(id);
            if (roolit == null)
            {
                return HttpNotFound();
            }
            return View(roolit);
        }

        // GET: Roolit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roolit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RooliID,Roolinimi")] Roolit roolit)
        {
            if (ModelState.IsValid)
            {
                db.Roolit.Add(roolit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roolit);
        }

        // GET: Roolit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roolit roolit = db.Roolit.Find(id);
            if (roolit == null)
            {
                return HttpNotFound();
            }
            return View(roolit);
        }

        // POST: Roolit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RooliID,Roolinimi")] Roolit roolit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roolit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roolit);
        }

        // GET: Roolit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roolit roolit = db.Roolit.Find(id);
            if (roolit == null)
            {
                return HttpNotFound();
            }
            return View(roolit);
        }

        // POST: Roolit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roolit roolit = db.Roolit.Find(id);
            db.Roolit.Remove(roolit);
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
