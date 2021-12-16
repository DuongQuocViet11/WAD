using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCar.Models;

namespace RentCar.Areas.Admin.Controllers
{
    public class DriverPricesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/DriverPrices
        public ActionResult Index()
        {
            return View(db.DriverPrices.ToList());
        }

        // GET: Admin/DriverPrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverPrice driverPrice = db.DriverPrices.Find(id);
            if (driverPrice == null)
            {
                return HttpNotFound();
            }
            return View(driverPrice);
        }

        // GET: Admin/DriverPrices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DriverPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,loaiXe,giaTheoGio,giaTheoNgay,giaTheoLoTrinh,ngayDang,ngaySua")] DriverPrice driverPrice)
        {
            if (ModelState.IsValid)
            {
                db.DriverPrices.Add(driverPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverPrice);
        }

        // GET: Admin/DriverPrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverPrice driverPrice = db.DriverPrices.Find(id);
            if (driverPrice == null)
            {
                return HttpNotFound();
            }
            return View(driverPrice);
        }

        // POST: Admin/DriverPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,loaiXe,giaTheoGio,giaTheoNgay,giaTheoLoTrinh,ngayDang,ngaySua")] DriverPrice driverPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverPrice);
        }

        // GET: Admin/DriverPrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverPrice driverPrice = db.DriverPrices.Find(id);
            if (driverPrice == null)
            {
                return HttpNotFound();
            }
            return View(driverPrice);
        }

        // POST: Admin/DriverPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverPrice driverPrice = db.DriverPrices.Find(id);
            db.DriverPrices.Remove(driverPrice);
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
