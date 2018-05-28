using RecipesGitHub.Models;
using RecipesGitHub.Models.DAO;
using RecipesGitHub.Models.display;
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
            List<DisplaySimpleRecipe> listOfREcipeWithNoImage = RecipeLoader.GetDisplaySimpleRecipes();


            return View(listOfREcipeWithNoImage);
        }

        public ActionResult SeeRecipe(String id)
        {
            FullRecipe objectToPass;
            if (id == "")
            {
                objectToPass = new FullRecipe();
            }
            else
            {
                objectToPass= RecipeLoader.GetFullRecipe(id);
                ViewBag.potato4 = objectToPass.Ingredients.Count;
                
            }
            //get the image from local files

            // send ther recipe with image object to the view

            return View(objectToPass);

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