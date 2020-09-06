using CoffeeShop.Models;
using System.Web.Mvc;
using CoffeeShop.ViewModel;
using System.Collections.Generic;


namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        //List<Order> Orders = new List<Order>();

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
            foreach (char let in pass)
            {
                if (let == '1' || let == '2' || let == '3' || let == '4' || let == '5' || let == '6' || let == '7' || let == '8' || let == '9' || let == '0')
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

            WebUser newUser = new WebUser
            {
                Name = $"{firstName} {lastName}",
                Email = eMail,
                Phone = phone,
                Pass = pass1,
                ID = WebUser.Users.Count
            };

            WebUser.Users.Add(newUser);
            
            return View(newUser);
        }

        public ActionResult WebOrder(string id)
        {
            int numid = int.Parse(id);

            var viewModel = new Order
            {
                Person = WebUser.Users[numid],
                ID = Order.Orders.Count,
                Stuff = new List<Item>(),
                Delivery = false,
                Time = System.DateTime.Now
            };

            Order.Orders.Add(viewModel);

            return View("AddItem", viewModel);
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

        public ActionResult AddItem(string DSelect, string Size, int orderNumber)
        {
            var viewModel = new Item 
            { 
                Size = Size, 
                Drink = DSelect 
            };

            Order.Orders[orderNumber].Stuff.Add(viewModel);
            
            return View("Another",Order.Orders[orderNumber]);
        }

        public ActionResult Another(int orderNumber)
        {
            //int numid = int.Parse(id);
            return View("AddItem", Order.Orders[orderNumber]);
        }

        public ActionResult Delivery(int orderNumber)
        {
            return View(Order.Orders[orderNumber]);
        }

        public ActionResult Checkout(string Delivery, int orderNumber)
        {
            if (Delivery == "Delivery")
            {
                Order.Orders[orderNumber].Delivery = true;
            }
            else
            {
                Order.Orders[orderNumber].Delivery = false;
            }
            Order.Orders[orderNumber].Time = System.DateTime.Now;


            return View(Order.Orders[orderNumber]);
        }
    }
}