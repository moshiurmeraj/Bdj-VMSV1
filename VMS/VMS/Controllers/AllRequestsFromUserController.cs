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
    public class AllRequestsFromUserController : Controller
    {
        private VmsContext db = new VmsContext();

        // GET: /AllRequestsFromUser/
        public ActionResult Index()
        {
            var allrequestsfromusers = db.AllRequestsFromUsers.Include(a => a.UserRequest);
            return View(allrequestsfromusers.ToList());
        }

        // GET: /AllRequestsFromUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllRequestsFromUser allrequestsfromuser = db.AllRequestsFromUsers.Find(id);
            if (allrequestsfromuser == null)
            {
                return HttpNotFound();
            }
            return View(allrequestsfromuser);
        }

        // GET: /AllRequestsFromUser/Create
        public ActionResult Create()
        {
            ViewBag.UserRequestId = new SelectList(db.UserRequests, "UserRequestId", "Purpose");
            return View();
        }

        // POST: /AllRequestsFromUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AllRequestsFromUserId,UserRequestId,RequestStatusName")] AllRequestsFromUser allrequestsfromuser)
        {
            if (ModelState.IsValid)
            {
                db.AllRequestsFromUsers.Add(allrequestsfromuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserRequestId = new SelectList(db.UserRequests, "UserRequestId", "Purpose", allrequestsfromuser.UserRequestId);
            return View(allrequestsfromuser);
        }

        // GET: /AllRequestsFromUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllRequestsFromUser allrequestsfromuser = db.AllRequestsFromUsers.Find(id);
            if (allrequestsfromuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserRequestId = new SelectList(db.UserRequests, "UserRequestId", "Purpose", allrequestsfromuser.UserRequestId);
            return View(allrequestsfromuser);
        }

        // POST: /AllRequestsFromUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AllRequestsFromUserId,UserRequestId,RequestStatusName")] AllRequestsFromUser allrequestsfromuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allrequestsfromuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserRequestId = new SelectList(db.UserRequests, "UserRequestId", "Purpose", allrequestsfromuser.UserRequestId);
            return View(allrequestsfromuser);
        }

        // GET: /AllRequestsFromUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllRequestsFromUser allrequestsfromuser = db.AllRequestsFromUsers.Find(id);
            if (allrequestsfromuser == null)
            {
                return HttpNotFound();
            }
            return View(allrequestsfromuser);
        }

        // POST: /AllRequestsFromUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllRequestsFromUser allrequestsfromuser = db.AllRequestsFromUsers.Find(id);
            db.AllRequestsFromUsers.Remove(allrequestsfromuser);
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
