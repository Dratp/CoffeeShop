using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult NewUser(string firstName, string lastName, string eMail, string phone, string pass1, string pass2)
        {
            bool match = false;
            ViewBag.Match = match;
            ViewBag.Name = $"{firstName} {lastName}";
            ViewBag.eMail = eMail;
            match = pass1.Equals(pass2);

            if (!match)
            {
                return Content($"The passwords do not match");
                
            }
            else
            {
                return View();
            }
        }

        public ActionResult PassNoMatch()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}