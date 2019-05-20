using OrderSys.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace OrderSys.Controllers
{
    public class MenuChoiceController : Controller
    {
        private AllContext db = new AllContext();
        // GET: MenuChoice
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
            if (test == null)
            {
                return Redirect("~/menuchoice/Create");
            }
            {
                var dbmc = (from s in db.MenuChoices
                            select s).ToList();
            }

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

        public ActionResult Create()
        {
            return View(db.Choices.ToList());
        }

        public ActionResult Add()
        {
            List<string> both = new List<string>();
            List<string> name = new List<string>();
            List<int> id = new List<int>();

            var today = DateTime.Today;
            var v = (from s in db.Menus
                     where DbFunctions.TruncateTime(s.Date) == today
                     select s).FirstOrDefault();

            if (v == null)
            {
                Menu n = new Menu(DateTime.Now);
                db.Menus.Add(n);
                db.SaveChanges();

            }

            var k = (from s in db.Menus
                     where DbFunctions.TruncateTime(s.Date) == today
                     select s).FirstOrDefault();

            {
                both = Request.QueryString.ToString().Split('&').ToList();
                foreach (var m in both)
                {
                    string comp = m.Split('=')[0];

                    var t = db.Choices.Where(x => x.Item == comp).Select(x => x.Id);
                    int i = t.First();

                    db.MenuChoices.Add(new MenuChoice(k.Id, i));
                    db.SaveChanges();
                }
            }
            return Redirect("Index");

        }
        public ActionResult Update()
        {
            return View(db.Choices.ToList());
        }

        public ActionResult UpOpp()
        {

            var today = DateTime.Today;

            var i = (from s in db.Menus
                     where DbFunctions.TruncateTime(s.Date) == today
                     select s).First();

            var w = from y in db.MenuChoices
                    where y.MenuId == i.Id
                    select y;

            foreach (var q in w)
            {
                db.MenuChoices.Remove(q);
            }
            db.SaveChanges();

            List<string> both = new List<string>();
            List<string> name = new List<string>();
            List<int> id = new List<int>();

            var k = (from s in db.Menus
                     where DbFunctions.TruncateTime(s.Date) == today
                     select s).First();
            both = Request.QueryString.ToString().Split('&').ToList();
            foreach (var m in both)
            {
                string comp = m.Split('=')[0];

                var t = db.Choices.Where(x => x.Item == comp).Select(x => x.Id);
                int e = t.First();

                db.MenuChoices.Add(new MenuChoice(k.Id, e));
                db.SaveChanges();
            }
            return Redirect("Index");
        }

    }
}