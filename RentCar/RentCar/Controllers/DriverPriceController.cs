using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class DriverPriceController : Controller
    {
        private DataContext context = new DataContext();
        // GET: DriverPrice
        public ActionResult Index()
        {
            var list = context.DriverPrices.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DriverPrice driverprice)
        {
            if (ModelState.IsValid)
            {
                context.DriverPrices.Add(driverprice);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverprice);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            DriverPrice driverprice = context.DriverPrices.Find(id);
            if (driverprice == null)
            {
                return HttpNotFound();
            }
            return View(driverprice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DriverPrice driverprice)
        {
            if (ModelState.IsValid)
            {
                context.Entry(driverprice).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverprice);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            
            DriverPrice category = context.DriverPrices.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            context.DriverPrices.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}