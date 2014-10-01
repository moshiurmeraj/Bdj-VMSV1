using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VMS.Models;

namespace VMS.Controllers
{
    public class UserRequestController : Controller
    {
        private VmsContext db = new VmsContext();

        // GET: /UserRequest/
        public ActionResult Index()
        {
            var userrequests = db.UserRequests.Include(u => u.Designation);
            return View(userrequests.ToList());
        }

        // GET: /UserRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRequest userrequest = db.UserRequests.Find(id);
            if (userrequest == null)
            {
                return HttpNotFound();
            }
            return View(userrequest);
        }

        // GET: /UserRequest/Create
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName");
            return View();
        }

        // POST: /UserRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserRequestId,JourneyStartTime,JourneyEndTime,Purpose,CompanyName,Destination,DesignationId")] UserRequest userrequest)
        {
            if (ModelState.IsValid)
            {
                db.UserRequests.Add(userrequest);
                db.SaveChanges();
                return RedirectToAction("user_message");
               
       

            }

            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", userrequest.DesignationId);
            return View(userrequest);
        }

        public ActionResult user_message()
        {
            return View();
        }

        // GET: /UserRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRequest userrequest = db.UserRequests.Find(id);
            if (userrequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", userrequest.DesignationId);
            return View(userrequest);
        }

        // POST: /UserRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserRequestId,JourneyStartTime,JourneyEndTime,Purpose,CompanyName,Destination,DesignationId")] UserRequest userrequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userrequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", userrequest.DesignationId);
            return View(userrequest);
        }

        // GET: /UserRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRequest userrequest = db.UserRequests.Find(id);
            if (userrequest == null)
            {
                return HttpNotFound();
            }
            return View(userrequest);
        }

        // POST: /UserRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRequest userrequest = db.UserRequests.Find(id);
            db.UserRequests.Remove(userrequest);
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
