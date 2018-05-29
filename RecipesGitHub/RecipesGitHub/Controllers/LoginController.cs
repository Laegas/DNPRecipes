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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login()
        {

            String username = Request.Form["username"];
            String password = Request.Form["password"];

            using(var db = new RecipeDBConnection())
            {
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