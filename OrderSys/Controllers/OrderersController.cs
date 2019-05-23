using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderSys.Models;

namespace OrderSys.Controllers
{
    
    public class OrderersController : Controller
    {
        private AllContext db = new AllContext();

        // GET: Orderers
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Orderers.ToList());
        }

        // GET: Orderers/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderer orderer = db.Orderers.Find(id);
            if (orderer == null)
            {
                return HttpNotFound();
            }
            return View(orderer);
        }

        // GET: Orderers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orderers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNo,College,Password,Username,Role")] Orderer orderer)
        {
            if (ModelState.IsValid)
            {
                db.Orderers.Add(orderer);
                db.SaveChanges();
                return RedirectToAction("Login","AuthAuth");
            }

            return View(orderer);
        }

        // GET: Orderers/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderer orderer = db.Orderers.Find(id);
            if (orderer == null)
            {
                return HttpNotFound();
            }
            return View(orderer);
        }

        // POST: Orderers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNo,College,Password,Username,Role")] Orderer orderer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Login", "AuthAuth");
            }
            return View(orderer);
        }

        // GET: Orderers/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderer orderer = db.Orderers.Find(id);
            if (orderer == null)
            {
                return HttpNotFound();
            }
            return View(orderer);
        }

        // POST: Orderers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Orderer orderer = db.Orderers.Find(id);
            db.Orderers.Remove(orderer);
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
