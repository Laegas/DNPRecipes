using RecipesGitHub.Models;
using RecipesGitHub.Models.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RecipesGitHub.Controllers
{
    public class UploadController : Controller
    {

        public static readonly String IMAGE_PATH = @"C:\Users\kenneth\source\repos\DNPRecipes\RecipesGitHub\RecipesGitHub\img\recipeImages\";


        /**
         * a method used to handle a post request for creating an account 
         */
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
                    if (AccountDAO.CreateAccount(new account(username, password)))
                    {
                        ViewBag.added = "yes";
                        return View();
                    }

                }

                ViewBag.added = "no";
                return View();

            }


            //return RedirectToAction("Index", "HomeController");
            return View();
        }

        /**
         * not used
         */
        public ActionResult Index()
        {
            return View();
        }


        /**
         * this was used to test how posing an image worked
         */
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase image_file)
        {
            if(SaveImage(image_file, Request.Form["recipeName"])) {
                return RedirectToAction("Index");
            }
            TempData["test1"]  = "no image was uploaded";
            return RedirectToAction("Index");

        }

        /**
         * used to save a posted image to the file system
         */
        private bool SaveImage(HttpPostedFileBase image_file, String recipeName)
        {
            if (image_file != null && image_file.ContentLength > 0)
            {

                String fileExtension = Path.GetExtension(image_file.FileName);

                System.IO.Directory.CreateDirectory(IMAGE_PATH + "/" + recipeName + "/");
                image_file.SaveAs(IMAGE_PATH + recipeName + "/" + recipeName + "." + fileExtension);

                return true ;
            }
            return false;
        }

        /**
         * a method used to create a recipe and insert it into the database using a DAO layer that utelizes entity framework
         */
        [HttpPost]
        public ActionResult CreateRecipe()
        {

            String recipeName = "";
            String longDescription= "";
            String shortDescription;
            String jsonIngredientList = null;

            HttpPostedFileBase image_file = Request.Files["image"];

            List<JsonIngredient> jsonIngredients = null;

            //if data is shit
            foreach (String key in Request.Form.AllKeys)
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
                if (key == "ingredients")
                {
                    jsonIngredientList = Request.Form[key];
                    jsonIngredients = new JavaScriptSerializer().Deserialize<List<JsonIngredient>>(jsonIngredientList);
                    ViewBag.test1 = jsonIngredientList + ":" + jsonIngredients;
                }

            }

            RecipeDAO.CreateRecipe(new FullRecipe(recipeName, longDescription, jsonIngredients));
            if (SaveImage(image_file, recipeName))
            {
                //save the file
                ViewBag.message = "the recipe have been saved";
                SaveImage(image_file, recipeName);
            }
            else
            {
                ViewBag.message = "the recipe was not saved";
            }


            return View();
        }
    }
}