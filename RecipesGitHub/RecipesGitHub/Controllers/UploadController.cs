using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesGitHub.Controllers
{
    public class UploadController : Controller
    {

        // POST: Upload
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateAccount()
        {
            String email = "";
            String username = "";
            String password = "";
            bool conditionsAccepted = false;

            //CreateAccount and insert into database
            foreach(String key in Request.Form.AllKeys)
            {
                if(key == "email")
                {
                    ViewBag.test1 = Request.Form[key];
                    email = Request.Form[key];

                }
                if (key == "username")
                {
                    ViewBag.test2 = Request.Form[key];
                    username = Request.Form[key];

                }
                if (key == "password")
                {
                    ViewBag.test3 = Request.Form[key];
                    password = "password";
                }
                if(key == "conditions")
                {
                    ViewBag.test4 = Request.Form[key];
                }

                if (Request.Form[key] == "on")
                {
                    conditionsAccepted = true;
                }
                else
                {
                    conditionsAccepted = false;
                }

                if (conditionsAccepted)
                {
                    //try to create the account
                    using(var db = new RecipeDBConnection())
                    {
                        try
                        {
                            db.accounts.Add(new account(username, password));
                            db.SaveChanges();
                            ViewBag.added = "yes";
                        }catch(Exception e)
                        {
                            ViewBag.added = "no";
                        }

                    }

                    return View();
                }



            }

            //ViewBag.test1 = Request.Form["email"];
            //ViewBag.test2 = Request.Form["username"];
            //ViewBag.test3 = Request.Form["password"];

            //return RedirectToAction("Index", "HomeController");
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase image_file)
        {
            if(image_file != null && image_file.ContentLength > 0) {

                //ViewBag.test1 = image_file.FileName;

                String fileName = Path.GetFileName(image_file.FileName);
                TempData["test1"] = "something good is going on, file name: " + fileName;

                image_file.SaveAs("c:\\users\\kenneth\\desktop\\image.jpg");
                
                return RedirectToAction("Index");

            }
            TempData["test1"]  = "no image was uploaded";
            return RedirectToAction("Index");

        }
    }
}