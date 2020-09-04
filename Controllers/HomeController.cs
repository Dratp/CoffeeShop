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

        public static bool ValidatePassword(string pass)
        {
            foreach(char let in pass)
            {
                if(let == '1' || let == '2' || let == '3' || let == '4' || let == '5' || let == '6' || let == '7' || let == '8' || let == '9' || let == '0')
                {
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        public ActionResult NewUser(string firstName, string lastName, string eMail, string phone, string pass1, string pass2)
        {
            bool match = false;
            bool validPass = true;
            ViewBag.Match = match;
            ViewBag.Name = $"{firstName} {lastName}";
            ViewBag.eMail = eMail;
            match = pass1.Equals(pass2);

            validPass = ValidatePassword(pass1);

            if (!validPass)
            {
                ViewBag.passStatus = "The password did not contain a number";
                return View("Register");
            }

            if (!match)
            {
                ViewBag.matchStatus = "The Passwords did not match";
                return View("Register");
                //return RedirectToAction("Register", "Home");
                //return Content($"The passwords do not match");
            }

            return View();
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