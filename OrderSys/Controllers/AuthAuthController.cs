using OrderSys.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace OrderSys.Controllers
{
    public class AuthAuthController : Controller
    {
        AllContext db = new AllContext();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Orderer orderer)
        {
            int count = (from x in db.Orderers
                         where x.Username == orderer.Username
                         where x.Password == orderer.Password
                         select x).Count();
            if (count == 0)
            {

                ViewBag.Message = "Login Error...Incorrect Username and/or password";

                return View();
            }
            else
            {
                string result = (from x in db.Orderers
                                 where x.Username == orderer.Username
                                 where x.Password == orderer.Password
                                 select x.Role).FirstOrDefault().ToString();

                string oid = (from x in db.Orderers
                                 where x.Username == orderer.Username
                                 where x.Password == orderer.Password
                                 select x.Id).FirstOrDefault().ToString();

                FormsAuthentication.SetAuthCookie(orderer.Username.ToString(), false);
                if (result == "admin")
                {
                    return RedirectToAction("Index", "MenuChoice");
                }
                else
                {
                    Session["orderid"] = oid;
                    //return RedirectToAction("Index", "Menus");
                    return RedirectToAction("oidtest", "Orders");
                }


            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AuthAuth");
        }
    }
}