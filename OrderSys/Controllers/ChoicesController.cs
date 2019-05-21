using OrderSys.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OrderSys.Controllers
{
    public class ChoicesController : Controller
    {
        private AllContext db = new AllContext();

        // GET: Choices
        public ActionResult Index()
        {

            var today = DateTime.Today;
            var mc = new MenuChoice();

            var dbmenus = (from s in db.Menus
                           where DbFunctions.TruncateTime(s.Date) == today
                           select s).ToList();
            var test = (from s in db.Menus
                        where DbFunctions.TruncateTime(s.Date) == today
                        select s).FirstOrDefault();

            var dbmc = (from s in db.MenuChoices
                        select s).ToList();

            var menus = from left in db.MenuChoices
                        join right in db.Choices on left.ChoiceId equals right.Id into temp
                        from right in temp.DefaultIfEmpty()
                        select new { left, right };

            var choices = from right in db.Choices
                          join left in db.MenuChoices on right.Id equals left.ChoiceId
                          into temp
                          from left in temp.DefaultIfEmpty()
                          select new { left, right };

            var f = menus.Union(choices);
            List<MenuChoice> mclist = new List<MenuChoice>(dbmenus.ToList().Count());

            for (int i = 0; i < dbmenus.Count; i++)
            {

                int j = dbmenus[i].Id;
                mc.Menu = dbmenus[i];
                mc.Choices = (from right in db.Choices
                              join left in db.MenuChoices on right.Id equals left.ChoiceId
                              into temp
                              from left in temp.DefaultIfEmpty()
                              where left.MenuId == j
                              select right).ToList();
                mclist.Add(new MenuChoice(mc.Menu, mc.Choices));
            }
            return View(mclist);
        }

        // GET: Choices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // GET: Choices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Choices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Item,Price,Pic")] Choice choice, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/images/choices/")
                                         + file.FileName);
                choice.Pic = file.FileName;
                db.Choices.Add(choice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(choice);
        }

        // GET: Choices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // POST: Choices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Item,Price,Pic")] Choice choice, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                file.SaveAs(HttpContext.Server.MapPath("~/images/choices/")
                                                      + file.FileName);
                choice.Pic = file.FileName;
                db.Entry(choice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(choice);
        }

        // GET: Choices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // POST: Choices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Choice choice = db.Choices.Find(id);
            db.Choices.Remove(choice);
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
