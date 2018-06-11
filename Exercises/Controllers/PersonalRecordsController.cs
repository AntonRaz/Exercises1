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
    public class PersonalRecordsController : Controller
    {
        private GymJournalDBContext db = new GymJournalDBContext();

        // GET: PersonalRecords
        public ActionResult Index()
        {
            var personalRecords = db.PersonalRecords.Include(p => p.SessionSet);
            return View(personalRecords.ToList());
        }

        // GET: PersonalRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalRecords personalRecords = db.PersonalRecords.Find(id);
            if (personalRecords == null)
            {
                return HttpNotFound();
            }
            return View(personalRecords);
        }

        // GET: PersonalRecords/Create
        public ActionResult Create()
        {
            ViewBag.SessionId = new SelectList(db.SessionSets, "SessionId", "Commentary");
            return View();
        }

        // POST: PersonalRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRId,Load,CurrentRecord,SessionId,SetNumber")] PersonalRecords personalRecords)
        {
            if (ModelState.IsValid)
            {
                db.PersonalRecords.Add(personalRecords);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SessionId = new SelectList(db.SessionSets, "SessionId", "Commentary", personalRecords.SessionId);
            return View(personalRecords);
        }

        // GET: PersonalRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalRecords personalRecords = db.PersonalRecords.Find(id);
            if (personalRecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.SessionId = new SelectList(db.SessionSets, "SessionId", "Commentary", personalRecords.SessionId);
            return View(personalRecords);
        }

        // POST: PersonalRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRId,Load,CurrentRecord,SessionId,SetNumber")] PersonalRecords personalRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SessionId = new SelectList(db.SessionSets, "SessionId", "Commentary", personalRecords.SessionId);
            return View(personalRecords);
        }

        // GET: PersonalRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalRecords personalRecords = db.PersonalRecords.Find(id);
            if (personalRecords == null)
            {
                return HttpNotFound();
            }
            return View(personalRecords);
        }

        // POST: PersonalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalRecords personalRecords = db.PersonalRecords.Find(id);
            db.PersonalRecords.Remove(personalRecords);
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
