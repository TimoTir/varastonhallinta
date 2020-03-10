﻿using System;
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
    public class ToimittajatController : Controller
    {
        private naytto1Entities1 db = new naytto1Entities1();

        // GET: Toimittajat
        public ActionResult Index()
        {
            return View(db.Toimittajat.ToList());
        }

        // GET: Toimittajat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimittajat toimittajat = db.Toimittajat.Find(id);
            if (toimittajat == null)
            {
                return HttpNotFound();
            }
            return View(toimittajat);
        }

        // GET: Toimittajat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Toimittajat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToimittajaID,YritysNmi,YhteysHenkilö,Puhelin")] Toimittajat toimittajat)
        {
            if (ModelState.IsValid)
            {
                db.Toimittajat.Add(toimittajat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toimittajat);
        }

        // GET: Toimittajat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimittajat toimittajat = db.Toimittajat.Find(id);
            if (toimittajat == null)
            {
                return HttpNotFound();
            }
            return View(toimittajat);
        }

        // POST: Toimittajat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToimittajaID,YritysNmi,YhteysHenkilö,Puhelin")] Toimittajat toimittajat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toimittajat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toimittajat);
        }

        // GET: Toimittajat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toimittajat toimittajat = db.Toimittajat.Find(id);
            if (toimittajat == null)
            {
                return HttpNotFound();
            }
            return View(toimittajat);
        }

        // POST: Toimittajat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toimittajat toimittajat = db.Toimittajat.Find(id);
            db.Toimittajat.Remove(toimittajat);
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
