using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DominosFrontEnd.Controllers
{
    /// <summary>
    /// This class is the home controller for the website
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// This class returns the home page of the website
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method returns the checkout page of the website
        /// </summary>
        [Authorize]
        public ActionResult Checkout()
        {
            return View();
        }
        /// <summary>
        /// This method returns the pizza menu of the website
        /// </summary>
        [Authorize]
        public ActionResult PizzaMenu()
        {
            return View();
        }
        /// <summary>
        /// This method returns the Order completion page of the website
        /// </summary>
        [Authorize]
        public ActionResult OrderCompletion()
        {
            return View();
        }
    }
}