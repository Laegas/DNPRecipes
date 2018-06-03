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
        /**
         * A list on simple reipe objects are retrived from the database, using the DAO pattern, 
         * where the implementation utelizes the entity framework
         * 
         */
        public ActionResult Index()
        {
            // get all recipes with images
            List<DisplaySimpleRecipe> listOfREcipeWithNoImage = RecipeDAO.GetDisplaySimpleRecipes();


            return View(listOfREcipeWithNoImage);
        }

        /**
         * A full recipe is retirved from the database using the id from the path as the name of the recipe 
         * 
         */
        public ActionResult SeeRecipe(String id)
        {
            FullRecipe objectToPass;
            if (id == "" || id == null)
            {
                objectToPass = new FullRecipe();
            }
            else
            {
                objectToPass= RecipeDAO.GetFullRecipe(id);
                
            }

            // send ther recipe with image object to the view
            return View(objectToPass);

        }

        public ActionResult CreateRecipe()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
    }
}