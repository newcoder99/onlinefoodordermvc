using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderFoodManagmentSystem;

namespace OnlineFoodOrderManagment.Views
{
    public class RestaurantsController : Controller
    {
        private OrderFoodManagementEntities db = new OrderFoodManagementEntities();

        // GET: Restaurants
        public ActionResult Index()
        {
            var tblRestaurants = db.tblRestaurants.Include(t => t.tblMenuItem);
            return View(tblRestaurants.ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRestaurant tblRestaurant = db.tblRestaurants.Find(id);
            if (tblRestaurant == null)
            {
                return HttpNotFound();
            }
            return View(tblRestaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            ViewBag.fooditemid = new SelectList(db.tblMenuItems, "fooditemid", "foodname");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "restaurantID,restaurantname,fooditemid")] tblRestaurant tblRestaurant)
        {
            if (ModelState.IsValid)
            {
                db.tblRestaurants.Add(tblRestaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fooditemid = new SelectList(db.tblMenuItems, "fooditemid", "foodname", tblRestaurant.fooditemid);
            return View(tblRestaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRestaurant tblRestaurant = db.tblRestaurants.Find(id);
            if (tblRestaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.fooditemid = new SelectList(db.tblMenuItems, "fooditemid", "foodname", tblRestaurant.fooditemid);
            return View(tblRestaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "restaurantID,restaurantname,fooditemid")] tblRestaurant tblRestaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRestaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fooditemid = new SelectList(db.tblMenuItems, "fooditemid", "foodname", tblRestaurant.fooditemid);
            return View(tblRestaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRestaurant tblRestaurant = db.tblRestaurants.Find(id);
            if (tblRestaurant == null)
            {
                return HttpNotFound();
            }
            return View(tblRestaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRestaurant tblRestaurant = db.tblRestaurants.Find(id);
            db.tblRestaurants.Remove(tblRestaurant);
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
