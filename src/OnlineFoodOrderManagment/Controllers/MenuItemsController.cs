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
    public class MenuItemsController : Controller
    {
        private OrderFoodManagementEntities db = new OrderFoodManagementEntities();

        // GET: MenuItems
        public ActionResult Index()
        {
            return View(db.tblMenuItems.ToList());
        }

        // GET: MenuItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMenuItem tblMenuItem = db.tblMenuItems.Find(id);
            if (tblMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(tblMenuItem);
        }

        // GET: MenuItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fooditemid,foodname")] tblMenuItem tblMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.tblMenuItems.Add(tblMenuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMenuItem);
        }

        // GET: MenuItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMenuItem tblMenuItem = db.tblMenuItems.Find(id);
            if (tblMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(tblMenuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fooditemid,foodname")] tblMenuItem tblMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMenuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMenuItem);
        }

        // GET: MenuItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMenuItem tblMenuItem = db.tblMenuItems.Find(id);
            if (tblMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(tblMenuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMenuItem tblMenuItem = db.tblMenuItems.Find(id);
            db.tblMenuItems.Remove(tblMenuItem);
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
