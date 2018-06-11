using Exercises.Models;
using Exercises.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class SessionBPSController : Controller
    {
        private GymJournalDBContext db = new GymJournalDBContext();

        // GET: SessionBPS
        public ActionResult Index()
        {
            List<SessionBPSViewModel> sessionBPVList = new List<SessionBPSViewModel>();

            var dataList = (from session in db.Sessions
                            join bps in db.BiopsychosocialStates on session.SessionId equals bps.BPSId
                            select new { session.SessionId, session.SessionDate, session.Commentary, bps.Fatigue, bps.Motivation, bps.SleepQuality, bps.Stiffness, bps.TrustInSelf }).ToList();

            foreach (var item in dataList)
            {
                var sBps = new SessionBPSViewModel();
                sBps.session = new Session();
                sBps.bps = new BiopsychosocialState();

                sBps.session.SessionId = item.SessionId;
                sBps.session.SessionDate = item.SessionDate;
                sBps.session.Commentary = item.Commentary;
                sBps.bps.Fatigue = item.Fatigue;
                sBps.bps.Motivation = item.Motivation;
                sBps.bps.SleepQuality = item.SleepQuality;
                sBps.bps.Stiffness = item.Stiffness;
                sBps.bps.TrustInSelf = item.TrustInSelf;

                sessionBPVList.Add(sBps);
            }

            return View(sessionBPVList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sBps = new SessionBPSViewModel
            {
                session = new Session(),
                bps = new BiopsychosocialState()
            };

            sBps.session = db.Sessions.Find(id);
            sBps.bps = db.BiopsychosocialStates.Find(id);

            if (sBps == null)
            {
                return HttpNotFound();
            }

            return View(sBps);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionBPSViewModel sBPS)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (sBPS.session.SessionId > 0)
                    {
                        var currentSets = db.SessionSets.Where(s => s.SessionId == sBPS.session.SessionId);

                        foreach (SessionSet ss in currentSets)
                            db.SessionSets.Remove(ss);

                        foreach (SessionSet ss in sBPS.session.Sets)
                            db.SessionSets.Add(ss);

                        db.Entry(sBPS).State = EntityState.Modified;
                    }
                    else
                    {
                        Session ses = new Session();
                        BiopsychosocialState bps = new BiopsychosocialState();

                        ses.Commentary = sBPS.session.Commentary;
                        ses.SessionDate = sBPS.session.SessionDate;
                        db.Sessions.Add(ses);
                        db.SaveChanges();

                        bps = sBPS.bps;
                        bps.BPSId = ses.SessionId;

                        db.BiopsychosocialStates.Add(bps);
                        db.SaveChanges();
                    }
                    //return RedirectToAction("Index");
                    return Json(new { Success = 1, SessionId = sBPS.session.SessionId, ex = "" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            //return View(sBPS);
            return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";

            var sBps = new SessionBPSViewModel
            {
                session = new Session(),
                bps = new BiopsychosocialState()
            };

            sBps.session = db.Sessions.Find(id);
            sBps.bps = db.BiopsychosocialStates.Find(id);

            //Call Create View
            return View("Create", sBps);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sBps = new SessionBPSViewModel
            {
                session = new Session(),
                bps = new BiopsychosocialState()
            };

            sBps.session = db.Sessions.Find(id);
            sBps.bps = db.BiopsychosocialStates.Find(id);
            if (sBps == null)
            {
                return HttpNotFound();
            }
            return View(sBps);
        }

        // POST: BiopsychosocialStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session session = db.Sessions.Find(id);
            db.Sessions.Remove(session);

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