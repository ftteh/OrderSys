using System.Collections.Generic;
using System.Web.Mvc;

namespace OrderSys.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Order
        public ActionResult Restriction()
        {
            List<string> opt = new List<string>();
            opt.Add("Open");
            opt.Add("Close");

            ViewBag.list = opt;
            return View(opt);
        }
    }
}