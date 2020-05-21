using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ClientApp.ViewModel;
using DTO;

namespace ClientApp.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44309/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Account/IsValidUser", user);
                    if (response.IsSuccessStatusCode)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        return RedirectToAction("pizzaMenu", "Home");
                    }
                }

            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44309/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Account/RegisterUser", user);
                    if (response.IsSuccessStatusCode)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        return RedirectToAction("pizzaMenu", "Home");
                    }
                }

            }
            ModelState.AddModelError("", "Something went wrong there");
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}