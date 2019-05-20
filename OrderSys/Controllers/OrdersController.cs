using OrderSys.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace OrderSys.Controllers
{
    public class OrdersController : Controller
    {
        private AllContext db = new AllContext();

        public ActionResult nMenu()
        {
            return View(db.Choices.ToList());
        }
        public ActionResult Add()
        {
            List<string> both = new List<string>();
            List<string> name = new List<string>();
            List<int> id = new List<int>();

            //var ordererid = 1;
            //var v = (from s in db.Orders
            //         where s.OrdererId == ordererid
            //         select s).FirstOrDefault();

            //if (v == null)
            //{
            //    //get the fields here and input it
            //    Order n = new Order("12/12/12", "12:12", "MA1", 12, ordererid);
            //    db.Orders.Add(n);
            //    db.SaveChanges();
            //}



            //var k = (from s in db.Orders
            //         where s.OrdererId == ordererid
            //         select s).FirstOrDefault();

            //{
            List<string> nm = new List<string>();
            both = Request.QueryString.ToString().Split('&').ToList();
            //foreach (var m in both)
            //{
            //    string comp = m.Split('=')[0];
            //    nm.Add(comp);
            //    //var t = db.Choices.Where(x => x.Item == comp).Select(x => x.Id);
            //    //int i = t.First();

            //    //db.OrderChoices.Add(new OrderChoice(k.Id, i));
            //    //db.SaveChanges();
            //}
            ViewBag.nm = both;
            //}
            //return Redirect("Index");
            return View();

        }

        public ActionResult nOrder()
        {
            var ordererid = 71;
            var oc = new OrderChoice();

            var dborders = (from s in db.Orders
                            where s.OrdererId == ordererid
                            select s).ToList();


            var test = (from s in db.Orders
                        where s.OrdererId == ordererid
                        select s).FirstOrDefault();

            if (test == null)
            {
                return Redirect("/Orders/nMenu");
            }
            {
                var dbmc = (from s in db.OrderChoices
                            select s).ToList();
            }

            var orders = from left in db.OrderChoices
                        join right in db.Choices on left.ChoiceId equals right.Id into temp
                        from right in temp.DefaultIfEmpty()
                        select new { left, right };

            var choices = from right in db.Choices
                          join left in db.OrderChoices on right.Id equals left.ChoiceId
                          into temp
                          from left in temp.DefaultIfEmpty()
                          select new { left, right };

            var f = orders.Union(choices);
            List<OrderChoice> oclist = new List<OrderChoice>(dborders.ToList().Count());

            for (int i = 0; i < dborders.Count; i++)
            {

                int j = dborders[i].Id;
                oc.Order= dborders[i];
                oc.Choices = (from right in db.Choices
                              join left in db.OrderChoices on right.Id equals left.ChoiceId
                              into temp
                              from left in temp.DefaultIfEmpty()
                              where left.OrderId == j
                              select right).ToList();
                oclist.Add(new OrderChoice(oc.Order, oc.Choices));
            }
            return View(oclist);
        }



        //// GET: MenuChoice

        //public ActionResult DisplayMenu()
        //{
        //    var mc = new MenuChoice();
        //    mc.Choices = (from p in db.Choices
        //                  select p).ToList() ;
        //    var a = new Order();
        //    a.MenuChoice = mc;
        //    return View(a);
        //}


        //public ActionResult Index()
        //{
        //    var mc = new MenuChoice();
        //    mc.Choices = (from p in db.Choices
        //                 select p).ToList();
        //    var a = new Order();
        //    a.MenuChoice = mc;
        //    return View(a);

        //}

        //[HttpGet]
        //public ActionResult Order()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Detail([Bind(Include = "Id,Date,Time,Location,Amount")] Order order)
        //{
        //    order.Username = "wong";
        //    db.Order.Add(order);
        //    db.SaveChanges();
        //    return View(order);

        //}

        //public ActionResult allOrders()
        //{
        //    var result = from p in db.Order
        //                 where p.Username == "wong"
        //                 select p;

        //    //here
        //     return View(result.ToList());
        //}

        //// GET: Orders1/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Order.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Date,Time,Location,Amount")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("allOrders");
        //    }
        //    return View(order);
        //}

        //// GET: Orders1/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Order.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Orders1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Order.Find(id);
        //    db.Order.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("allOrders");
        //}

    }
}