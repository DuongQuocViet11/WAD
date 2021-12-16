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
    public class CarPricesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/CarPrices
        public ActionResult Index()
        {
            return View(db.CarPrices.ToList());
        }

        // GET: Admin/CarPrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarPrice carPrice = db.CarPrices.Find(id);
            if (carPrice == null)
            {
                return HttpNotFound();
            }
            return View(carPrice);
        }

        // GET: Admin/CarPrices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CarPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,loaiXe,soGhe,giaTheoGio,giaTheoNgay,giaTheoLoTrinh,ngayDang,ngaySua")] CarPrice carPrice)
        {
            if (ModelState.IsValid)
            {
                db.CarPrices.Add(carPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carPrice);
        }

        // GET: Admin/CarPrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarPrice carPrice = db.CarPrices.Find(id);
            if (carPrice == null)
            {
                return HttpNotFound();
            }
            return View(carPrice);
        }

        // POST: Admin/CarPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,loaiXe,soGhe,giaTheoGio,giaTheoNgay,giaTheoLoTrinh,ngayDang,ngaySua")] CarPrice carPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carPrice);
        }

        // GET: Admin/CarPrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarPrice carPrice = db.CarPrices.Find(id);
            if (carPrice == null)
            {
                return HttpNotFound();
            }
            return View(carPrice);
        }

        // POST: Admin/CarPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarPrice carPrice = db.CarPrices.Find(id);
            db.CarPrices.Remove(carPrice);
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
