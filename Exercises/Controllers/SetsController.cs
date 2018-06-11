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
    public class SetsController : Controller
    {
        private GymJournalDBContext db = new GymJournalDBContext();

        // GET: Sets
        public ActionResult Index()
        {
            var sets = db.SessionSets.Include(s => s.Exercise).Include(s => s.Session);
            return View(sets.ToList());
        }

        // GET: Sets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSet set = db.SessionSets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            return View(set);
        }
        
        // GET: Sets/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name");
            ViewBag.SessionId = new SelectList(db.Sessions, "SessionId", "Commentary");
            return View();
        }

        // POST: Sets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionId,SetNumber,ExerciseID,Reps,RPE,Load,Commentary,PersonalRecord")] SessionSet set)
        {
            if (ModelState.IsValid)
            {
                db.SessionSets.Add(set);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", set.ExerciseID);
            ViewBag.SessionId = new SelectList(db.Sessions, "SessionId", "Commentary", set.SessionId);
            return View(set);
        }

        // GET: Sets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSet set = db.SessionSets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", set.ExerciseID);
            ViewBag.SessionId = new SelectList(db.Sessions, "SessionId", "Commentary", set.SessionId);
            return View(set);
        }

        // POST: Sets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionId,SetNumber,ExerciseID,Reps,RPE,Load,Commentary,PersonalRecord")] SessionSet set)
        {
            if (ModelState.IsValid)
            {
                db.Entry(set).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ExerciseID", "Name", set.ExerciseID);
            ViewBag.SessionId = new SelectList(db.Sessions, "SessionId", "Commentary", set.SessionId);
            return View(set);
        }

        // GET: Sets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionSet set = db.SessionSets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            return View(set);
        }

        // POST: Sets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionSet set = db.SessionSets.Find(id);
            db.SessionSets.Remove(set);
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
