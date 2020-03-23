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
    public class TuotteetController : Controller
    {
        private naytto1Entities1 db = new naytto1Entities1();

        // GET: Tuotteet
        public ActionResult Index(string searching)
        {
            //var tuotteet = db.Tuotteet.Include(t => t.Toimittajat);
            //return View(tuotteet.ToList());
            return View(db.Tuotteet.Where(x => x.TuoteMerkki.Contains(searching) ||
            x.TuoteMalli.Contains(searching) ||
            x.Sarjanumero.Contains(searching)||
            x.Toimittajat.YritysNmi.Contains(searching) ||
            searching == null).ToList());
        }

        // GET: Tuotteet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuotteet tuotteet = db.Tuotteet.Find(id);
            if (tuotteet == null)
            {
                return HttpNotFound();
            }
            return View(tuotteet);
        }

        // GET: Tuotteet/Create
        public ActionResult Create()
        {
            ViewBag.ToimittajaID = new SelectList(db.Toimittajat, "ToimittajaID", "YritysNmi");
            ViewBag.LuokitteluID = new SelectList(db.TuoteLuokittelu, "LuokitteluID", "TuoteLuokat");
            return View();
        }

        // POST: Tuotteet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TuoteID,TuoteMerkki,TuoteMalli,Sarjanumero,Määrä,ToimittajaID,TuoteLuokat,VastanottoPvm")] Tuotteet tuotteet)
        {
            if (ModelState.IsValid)
            {
                db.Tuotteet.Add(tuotteet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ToimittajaID = new SelectList(db.Toimittajat, "ToimittajaID", "YritysNmi", tuotteet.ToimittajaID);
            return View(tuotteet);
        }

        // GET: Tuotteet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuotteet tuotteet = db.Tuotteet.Find(id);
            if (tuotteet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ToimittajaID = new SelectList(db.Toimittajat, "ToimittajaID", "YritysNmi", tuotteet.ToimittajaID);
            return View(tuotteet);
        }

        // POST: Tuotteet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TuoteID,TuoteNimi,TuoteMalli,Sarjanumero,Määrä,ToimittajaID,TuoteLuokat,VastanottoPvm")] Tuotteet tuotteet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuotteet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ToimittajaID = new SelectList(db.Toimittajat, "ToimittajaID", "YritysNmi", tuotteet.ToimittajaID);
            return View(tuotteet);
        }

        // GET: Tuotteet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuotteet tuotteet = db.Tuotteet.Find(id);
            if (tuotteet == null)
            {
                return HttpNotFound();
            }
            return View(tuotteet);
        }

        // POST: Tuotteet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tuotteet tuotteet = db.Tuotteet.Find(id);
            db.Tuotteet.Remove(tuotteet);
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
