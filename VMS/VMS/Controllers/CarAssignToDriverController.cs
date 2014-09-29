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
    public class CarAssignToDriverController : Controller
    {
        private VmsContext db = new VmsContext();

        // GET: /CarAssignToDriver/
        public ActionResult Index()
        {
            var carassigntodrivers = db.CarAssignToDrivers.Include(c => c.Cars).Include(c => c.Drivers);
            return View(carassigntodrivers.ToList());
        }

        // GET: /CarAssignToDriver/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarAssignToDriver carassigntodriver = db.CarAssignToDrivers.Find(id);
            if (carassigntodriver == null)
            {
                return HttpNotFound();
            }
            return View(carassigntodriver);
        }

        // GET: /CarAssignToDriver/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "CarName");
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "DriverName");
            return View();
        }

        // POST: /CarAssignToDriver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CarAssignToDriverId,CarId,DriverId,FromCarAssignDate,ToCarAssignDate")] CarAssignToDriver carassigntodriver)
        {
            if (ModelState.IsValid)
            {
                db.CarAssignToDrivers.Add(carassigntodriver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "CarId", "CarName", carassigntodriver.CarId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "DriverName", carassigntodriver.DriverId);
            return View(carassigntodriver);
        }

        // GET: /CarAssignToDriver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarAssignToDriver carassigntodriver = db.CarAssignToDrivers.Find(id);
            if (carassigntodriver == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "CarName", carassigntodriver.CarId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "DriverName", carassigntodriver.DriverId);
            return View(carassigntodriver);
        }

        // POST: /CarAssignToDriver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CarAssignToDriverId,CarId,DriverId,FromCarAssignDate,ToCarAssignDate")] CarAssignToDriver carassigntodriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carassigntodriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "CarName", carassigntodriver.CarId);
            ViewBag.DriverId = new SelectList(db.Drivers, "DriverId", "DriverName", carassigntodriver.DriverId);
            return View(carassigntodriver);
        }

        // GET: /CarAssignToDriver/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarAssignToDriver carassigntodriver = db.CarAssignToDrivers.Find(id);
            if (carassigntodriver == null)
            {
                return HttpNotFound();
            }
            return View(carassigntodriver);
        }

        // POST: /CarAssignToDriver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarAssignToDriver carassigntodriver = db.CarAssignToDrivers.Find(id);
            db.CarAssignToDrivers.Remove(carassigntodriver);
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
