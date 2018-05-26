using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesGitHub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // get all recipes with images
            List<RECIPE> listOfREcipeWithNoImage = new List<RECIPE>();

            using(var db = new Entities1()) {

                System.Data.Entity.DbSet<RECIPE> recipes = db.RECIPEs;
                ViewBag.potato = "shiit";
                foreach(var recipe in recipes)
                {
                    listOfREcipeWithNoImage.Add(recipe);
                    ViewBag.potato = "yaay";
                    break;
                }

            }

            // create list of recipes with the images and send to view

            return View(listOfREcipeWithNoImage);
        }

        public ActionResult SeeRecipe(String id)
        {

            RECIPE recipeWithoutImage = null;
            // get the person from database
            using (var db = new Entities1())
            {
                System.Data.Entity.DbSet <RECIPE> recipes = db.RECIPEs;
                int counter = 0;
                foreach(var aRecipe in recipes)
                {
                    counter++;
                    ViewBag.potato1 = aRecipe.NAME;
                    ViewBag.potato2 = id;
                    if (aRecipe.NAME.Equals(id))
                    {
                        recipeWithoutImage = aRecipe;
                        ViewBag.potato1 = "yaaaaaa";
                        ViewBag.potato2 = "success";
                        ViewBag.potato3 = aRecipe;
                        return View(aRecipe);
                    }
                }

            }

            //get the image from local files

            // send ther recipe with image object to the view

            return View(recipeWithoutImage);

        }

        public ActionResult CreateRecipe()
        {
            return View();
        }

        public ActionResult CreateAccount(int id)
        {
            ViewBag.myID = "id";
            return View();
        }
    }
}