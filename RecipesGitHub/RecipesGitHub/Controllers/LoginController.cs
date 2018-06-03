using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesGitHub.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /**
         * this method uses post data to log a user in using username and password.
         * If the user credentials are correct a cookie will be set with the key USERNAME and the actual username as the keyord
         * This is obviously not secure but is purely done for demonstrations purpose.
         */
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login()
        {

            String username = Request.Form["username"];
            String password = Request.Form["password"];

            using(var db = new RecipeDBConnection())
            {
                //using a bit of linq to generate a query on the entity database connection
                var dbPassword = from item in db.accounts where item.USERNAME == username select item.PASSWORD;

                foreach(String dbpass in dbPassword)
                {
                    if(dbpass == password)
                    {
                        //set the username as a cookie as proof of login
                        HttpCookie UsernameCookie = new HttpCookie("USERNAME");
                        UsernameCookie.Value = username;
                        HttpContext.Response.Cookies.Add(UsernameCookie);
                        //if success
                        ViewBag.loggedIn = "yes";
                        ViewBag.username = "username";
                        return View();
                    }
                }
            }



            return View();
        }
    }
}