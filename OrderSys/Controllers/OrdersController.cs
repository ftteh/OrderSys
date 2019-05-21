﻿using OrderSys.Models;
using System;
using System.Collections.Generic;
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

            var ordererid = 1;
            int Amount = 0;
            //add to the order first
            List<string> choi = new List<string>();
            string Date = "";
            string Time = "";
            string Location = "";

            both = Request.QueryString.ToString().Split('&').ToList();
            foreach (var m in both)
            {
                string comp = m.Split('=')[0];
                string sec = m.Split('=')[1];
                if (comp.Equals("Date"))
                {
                    Date = sec;
                    ViewBag.Date = sec;
                    continue;
                }
                else if (comp.Equals("Time"))
                {
                    Time = Uri.UnescapeDataString(sec);
                    ViewBag.Time = sec;
                    continue;
                }
                else if (comp.Equals("Location"))
                {
                    Location = sec;
                    ViewBag.Location = sec;
                    continue;
                }
                else
                {
                    Amount = Amount + int.Parse(sec);
                    continue;
                }
            }
            Order n = new Order(Date, Time, Location, Amount, ordererid);
            db.Orders.Add(n);
            db.SaveChanges();

            var k = (from s in db.Orders
                     where s.OrdererId == ordererid
                     && s.Date == Date &&
                     s.Time == Time
                     select s).FirstOrDefault();

            Amount = 0;
            both = Request.QueryString.ToString().Split('&').ToList();
            foreach (var m in both)
            {
                string comp = m.Split('=')[0];
                string sec = m.Split('=')[1];
                if (comp.Equals("Date"))
                {
                    Date = sec;
                    ViewBag.Date = sec;
                    continue;
                }
                else if (comp.Equals("Time"))
                {
                    Time = sec;
                    ViewBag.Time = sec;
                    continue;
                }
                else if (comp.Equals("Location"))
                {
                    Location = sec;
                    ViewBag.Location = sec;
                    continue;
                }
                else
                {
                    choi.Add(comp);
                    Amount = Amount + int.Parse(sec);
                    ViewBag.Amount = Amount;

                    var t = db.Choices.Where(x => x.Item == comp).Select(x => x.Id);
                    int i = t.First();
                    db.OrderChoices.Add(new OrderChoice(k.Id, i));
                }

                db.SaveChanges();
            }
            //ViewBag.choi = choi;
            return Redirect("nOrder");

        }

        public ActionResult nOrder()
        {
            var ordererid = 1;
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
            var dbmc = (from s in db.OrderChoices
                        select s).ToList();


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
                oc.Order = dborders[i];
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

        public ActionResult nEdit()
        {
            List<string> both = Request.QueryString.ToString().Split('&').ToList();
            int orderid = int.Parse(both[0].Split('=')[1]);
            var i = (from s in db.Orders
                     where s.Id == orderid
                     select s).First();

            ViewBag.thing = i;

            return View(db.Choices.ToList());
        }
        public ActionResult UpOpp()
        {
            var orderId = 1;
            List<string> both = Request.QueryString.ToString().Split('&').ToList();
            foreach (var m in both)
            {
                string comp = m.Split('=')[0];
                if (comp == "orderid")
                {
                    orderId = int.Parse(m.Split('=')[1]);
                    break;
                }
            }
            var ordererId = 1;

            var i = (from s in db.Orders
                     where s.OrdererId == ordererId &&
                     s.Id == orderId
                     select s).First();

            var w = from y in db.OrderChoices
                    where y.OrderId == i.Id
                    select y;

            foreach (var q in w)
            {
                db.OrderChoices.Remove(q);
            }
            db.Orders.Remove(i);
            db.SaveChanges();

            List<string> name = new List<string>();
            List<int> id = new List<int>();

            var ordererid = 1;
            int Amount = 0;

            string Date = "";
            string Time = "";
            string Location = "";

            both = Request.QueryString.ToString().Split('&').ToList();
            foreach (var m in both)
            {
                string comp = m.Split('=')[0];
                string sec = m.Split('=')[1];
                if (comp.Equals("Date"))
                {
                    Date = sec;
                    ViewBag.Date = sec;
                    continue;
                }
                else if (comp.Equals("Time"))
                {
                    Time = Uri.UnescapeDataString(sec);
                    ViewBag.Time = sec;
                    continue;
                }
                else if (comp.Equals("Location"))
                {
                    Location = sec;
                    ViewBag.Location = sec;
                    continue;
                }
                else if (comp.Equals("orderid"))
                {
                    continue;
                }

                else
                {
                    Amount = Amount + int.Parse(sec);
                    continue;
                }
            }
            Order n = new Order(Date, Time, Location, Amount, ordererid);
            db.Orders.Add(n);
            db.SaveChanges();

            var k = (from s in db.Orders
                     where s.OrdererId == ordererid
                     && s.Date == Date
                     && s.Time == Time
                     select s).FirstOrDefault();

            both = Request.QueryString.ToString().Split('&').ToList();
            foreach (var m in both)
            {
                string comp = m.Split('=')[0];
                string sec = m.Split('=')[1];
                if (comp == "Date" || comp == "Time" || comp == "Location" || comp == "orderid")
                {
                    continue;
                }

                var t = db.Choices.Where(x => x.Item == comp).Select(x => x.Id);
                int p = t.First();
                db.OrderChoices.Add(new OrderChoice(k.Id, p));

                db.SaveChanges();
            }
            return Redirect("nOrder");
        }

        public ActionResult Del()
        {
            string orderid = Request.QueryString.ToString().Split('&').First().Split('=')[1];
            int oid = int.Parse(orderid);

            var t = (from s in db.Orders
                     where s.Id == oid
                     select s).First();

            db.Orders.Remove(t);
            db.SaveChanges();

            return Redirect("nOrder");
        }


    }
}