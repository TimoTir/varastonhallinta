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
    public class TilauksetController : Controller
    {
        private naytto1Entities1 db = new naytto1Entities1();

        // GET: Tilaukset
        public ActionResult Index()
        {
            var tilaukset = db.Tilaukset.Include(t => t.Asiakkaat).Include(t => t.Tuotteet);
            return View(tilaukset.ToList());
        }

        // GET: Tilaukset/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaukset tilaukset = db.Tilaukset.Find(id);
            if (tilaukset == null)
            {
                return HttpNotFound();
            }
            return View(tilaukset);
        }

        // GET: Tilaukset/Create
        public ActionResult Create()
        {
            ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "YritysNimi");
            ViewBag.TuoteID = new SelectList(db.Tuotteet, "TuoteID", "TuoteMerkki");
            return View();
        }

        // POST: Tilaukset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TilausID,TuoteID,Määrä,AsiakasID")] Tilaukset tilaukset)
        {
            if (ModelState.IsValid)
            {
                db.Tilaukset.Add(tilaukset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "YritysNimi", tilaukset.AsiakasID);
            ViewBag.TuoteID = new SelectList(db.Tuotteet, "TuoteID", "TuoteMerkki", tilaukset.TuoteID);
            return View(tilaukset);
        }

        // GET: Tilaukset/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaukset tilaukset = db.Tilaukset.Find(id);
            if (tilaukset == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "YritysNimi", tilaukset.AsiakasID);
            ViewBag.TuoteID = new SelectList(db.Tuotteet, "TuoteID", "TuoteMerkki", tilaukset.TuoteID);
            return View(tilaukset);
        }

        // POST: Tilaukset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TilausID,TuoteID,Määrä,AsiakasID")] Tilaukset tilaukset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tilaukset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsiakasID = new SelectList(db.Asiakkaat, "AsiakasID", "YritysNimi", tilaukset.AsiakasID);
            ViewBag.TuoteID = new SelectList(db.Tuotteet, "TuoteID", "TuoteMerkki", tilaukset.TuoteID);
            return View(tilaukset);
        }

        // GET: Tilaukset/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tilaukset tilaukset = db.Tilaukset.Find(id);
            if (tilaukset == null)
            {
                return HttpNotFound();
            }
            return View(tilaukset);
        }

        // POST: Tilaukset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tilaukset tilaukset = db.Tilaukset.Find(id);
            db.Tilaukset.Remove(tilaukset);
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
