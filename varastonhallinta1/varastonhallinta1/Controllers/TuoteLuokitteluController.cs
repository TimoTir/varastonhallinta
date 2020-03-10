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
    public class TuoteLuokitteluController : Controller
    {
        private naytto1Entities1 db = new naytto1Entities1();

        // GET: TuoteLuokittelu
        public ActionResult Index()
        {
            return View(db.TuoteLuokittelu.ToList());
        }

        // GET: TuoteLuokittelu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuoteLuokittelu tuoteLuokittelu = db.TuoteLuokittelu.Find(id);
            if (tuoteLuokittelu == null)
            {
                return HttpNotFound();
            }
            return View(tuoteLuokittelu);
        }

        // GET: TuoteLuokittelu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TuoteLuokittelu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LuokitteluID,TuoteLuokka")] TuoteLuokittelu tuoteLuokittelu)
        {
            if (ModelState.IsValid)
            {
                db.TuoteLuokittelu.Add(tuoteLuokittelu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuoteLuokittelu);
        }

        // GET: TuoteLuokittelu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuoteLuokittelu tuoteLuokittelu = db.TuoteLuokittelu.Find(id);
            if (tuoteLuokittelu == null)
            {
                return HttpNotFound();
            }
            return View(tuoteLuokittelu);
        }

        // POST: TuoteLuokittelu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LuokitteluID,TuoteLuokka")] TuoteLuokittelu tuoteLuokittelu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuoteLuokittelu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuoteLuokittelu);
        }

        // GET: TuoteLuokittelu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuoteLuokittelu tuoteLuokittelu = db.TuoteLuokittelu.Find(id);
            if (tuoteLuokittelu == null)
            {
                return HttpNotFound();
            }
            return View(tuoteLuokittelu);
        }

        // POST: TuoteLuokittelu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TuoteLuokittelu tuoteLuokittelu = db.TuoteLuokittelu.Find(id);
            db.TuoteLuokittelu.Remove(tuoteLuokittelu);
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
