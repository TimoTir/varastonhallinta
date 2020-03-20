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
    public class VarastoSaldotController : Controller
    {
        private naytto1Entities1 db = new naytto1Entities1();

        // GET: VarastoSaldot
        public ActionResult Index(string searching)
        {
            //var varastoSaldot = db.VarastoSaldot.Include(v => v.Tuotteet);
            //return View(varastoSaldot.ToList());
            return View(db.VarastoSaldot.Where(x => x.Tuotemerkki.Contains(searching) || searching == null).ToList());
        }

        // GET: VarastoSaldot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarastoSaldot varastoSaldot = db.VarastoSaldot.Find(id);
            if (varastoSaldot == null)
            {
                return HttpNotFound();
            }
            return View(varastoSaldot);
        }

        // GET: VarastoSaldot/Create
        public ActionResult Create()
        {
            ViewBag.TuoteID = new SelectList(db.Tuotteet, "TuoteID", "TuoteMerkki");
            return View();
        }

        // POST: VarastoSaldot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VarastoID,TuoteID,Tuotemerkki,Määrä,VarastoPaikka")] VarastoSaldot varastoSaldot)
        {
            if (ModelState.IsValid)
            {
                db.VarastoSaldot.Add(varastoSaldot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TuoteID = new SelectList(db.Tuotteet, "TuoteID", "TuoteMerkki", varastoSaldot.TuoteID);
            return View(varastoSaldot);
        }

        // GET: VarastoSaldot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarastoSaldot varastoSaldot = db.VarastoSaldot.Find(id);
            if (varastoSaldot == null)
            {
                return HttpNotFound();
            }
            ViewBag.TuoteID = new SelectList(db.Tuotteet, "TuoteID", "TuoteMerkki", varastoSaldot.TuoteID);
            return View(varastoSaldot);
        }

        // POST: VarastoSaldot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VarastoID,TuoteID,Tuotemerkki,Määrä,VarastoPaikka")] VarastoSaldot varastoSaldot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(varastoSaldot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TuoteID = new SelectList(db.Tuotteet, "TuoteID", "TuoteMerkki", varastoSaldot.TuoteID);
            return View(varastoSaldot);
        }

        // GET: VarastoSaldot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarastoSaldot varastoSaldot = db.VarastoSaldot.Find(id);
            if (varastoSaldot == null)
            {
                return HttpNotFound();
            }
            return View(varastoSaldot);
        }

        // POST: VarastoSaldot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VarastoSaldot varastoSaldot = db.VarastoSaldot.Find(id);
            db.VarastoSaldot.Remove(varastoSaldot);
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
