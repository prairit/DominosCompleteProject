using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Menu()
        {
            return View();
        }

        [Authorize]
        public ActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        public ActionResult PizzaMenu()
        {
            return View();
        }
        [Authorize]
        public ActionResult OrderCompletion()
        {
            return View();
        }
    }
}