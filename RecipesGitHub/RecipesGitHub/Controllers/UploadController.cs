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

        public static readonly String IMAGE_PATH = @"C:\Users\kenneth\source\repos\DNPRecipes\RecipesGitHub\RecipesGitHub\img\recipeImages\";


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

                String fileExtension = Path.GetExtension(image_file.FileName);
                String recipeName = Request.Form["recipeName"];

                System.IO.Directory.CreateDirectory(IMAGE_PATH + "\\" + recipeName);
                image_file.SaveAs(IMAGE_PATH + recipeName + "\\" + recipeName + "." + fileExtension);


                //TempData["test1"] = "something good is going on, file name: " + fileName;

                
                return RedirectToAction("Index");

            }
            TempData["test1"]  = "no image was uploaded";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult CreateRecipe(HttpPostedFile image)
        {

            String recipeName;
            String longDescription;
            String shortDescription;
            String jsonIngredientList;

            //if data is shit
            foreach(String key in Request.Form.AllKeys)
            {
                if(key == "name"){
                    recipeName = Request.Form[key];
                }
                if (key == "short_desc")
                {
                    shortDescription= Request.Form[key];
                }
                if (key == "long_desc")
                {
                    longDescription = Request.Form[key];
                }
                if(key == "ingredients")
                {
                    jsonIngredientList = Request.Form[key];
                }
               


            }

            return View();
        }
    }
}