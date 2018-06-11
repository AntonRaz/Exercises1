using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exercises.Models;

namespace Exercises.Controllers
{
    public class BiopsychosocialStatesController : Controller
    {
        private GymJournalDBContext db = new GymJournalDBContext();

        // GET: BiopsychosocialStates
        public ActionResult Index()
        {
            return View(db.BiopsychosocialStates.ToList());
        }

        // GET: BiopsychosocialStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiopsychosocialState biopsychosocialState = db.BiopsychosocialStates.Find(id);
            if (biopsychosocialState == null)
            {
                return HttpNotFound();
            }
            return View(biopsychosocialState);
        }

        // GET: BiopsychosocialStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BiopsychosocialStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BPSId,SleepQuality,TrustInSelf,Stress")] BiopsychosocialState biopsychosocialState)
        {
            if (ModelState.IsValid)
            {
                db.BiopsychosocialStates.Add(biopsychosocialState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biopsychosocialState);
        }

        // GET: BiopsychosocialStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiopsychosocialState biopsychosocialState = db.BiopsychosocialStates.Find(id);
            if (biopsychosocialState == null)
            {
                return HttpNotFound();
            }
            return View(biopsychosocialState);
        }

        // POST: BiopsychosocialStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BPSId,SleepQuality,TrustInSelf,Stress")] BiopsychosocialState biopsychosocialState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biopsychosocialState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biopsychosocialState);
        }

        // GET: BiopsychosocialStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiopsychosocialState biopsychosocialState = db.BiopsychosocialStates.Find(id);
            if (biopsychosocialState == null)
            {
                return HttpNotFound();
            }
            return View(biopsychosocialState);
        }

        // POST: BiopsychosocialStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BiopsychosocialState biopsychosocialState = db.BiopsychosocialStates.Find(id);
            db.BiopsychosocialStates.Remove(biopsychosocialState);
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
