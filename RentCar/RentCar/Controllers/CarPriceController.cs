using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class CarPriceController : Controller
    {
        private DataContext context = new DataContext();
        // GET: CarPrice
        public ActionResult Index()
        {
            var list = context.CarPrices.ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarPrice carprice)
        {
            if (ModelState.IsValid)
            {
                context.CarPrices.Add(carprice);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carprice);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            
            CarPrice carprice = context.CarPrices.Find(id);
            if (carprice == null)
            {
                return HttpNotFound();
            }
            return View(carprice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarPrice carprice)
        {
            if (ModelState.IsValid)
            {
                context.Entry(carprice).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carprice);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            
            CarPrice carprice = context.CarPrices.Find(id);
            if (carprice == null)
            {
                return HttpNotFound();
            }
            context.CarPrices.Remove(carprice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}