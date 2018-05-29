using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesGitHub.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult CreateAccount()
        {
            //CreateAccount and insert into database

            ViewBag.test1 = Request.Form["email"];
            ViewBag.test2 = Request.Form["username"];
            ViewBag.test3 = Request.Form["password"];

            //return RedirectToAction("Index", "HomeController");
            return View();
        }
    }
}