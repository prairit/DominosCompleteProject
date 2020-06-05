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
using DominosFrontEnd.ViewModel;
using DTO;

namespace DominosFrontEnd.Controllers
{
    /// <summary>
    /// This class is the controller for home in the Dominos website
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// This method returns the homepage of the website
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This method returns the view for loggin a user in
        /// </summary>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// This method is a post action method which takes in user details and makes an API call to validate the user
        /// </summary>
        /// <param name="user">ViewModel object of the user</param>
        /// <returns>Redirects to pizza menu on successful validation</returns>
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
                        var token =response.Content.ReadAsStringAsync();
                        HttpCookie cookieToken= new HttpCookie("token");
                        cookieToken.Value = token.Result;
                        Response.Cookies.Add(cookieToken);
                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        return RedirectToAction("pizzaMenu", "Home");
                    }
                }

            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View();
        }
        /// <summary>
        /// This method returns the view for registering a user 
        /// </summary>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// This method is a post action method which takes in user details and makes an API call to register the user
        /// </summary>
        /// <param name="user">ViewModel object of the user</param>
        /// <returns>Redirects to pizza menu on successful validation</returns>
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
                        var token = response.Content.ReadAsStringAsync();
                        HttpCookie cookieToken = new HttpCookie("token");
                        cookieToken.Value = token.Result;
                        Response.Cookies.Add(cookieToken);
                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        return RedirectToAction("pizzaMenu", "Home");
                    }
                }

            }
            ModelState.AddModelError("", "Something went wrong there");
            return View();
        }
        /// <summary>
        /// This method removes the user cookies on logging out
        /// </summary>
        /// <returns>Redirects to homepage</returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}