using RecipesGitHub.Models.display;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models.DAO
{
    public class RecipeLoader
    {

        public static void Main()
        {
            FullRecipe recipe = GetFullRecipe("spagettieRecipe");
        }
        //load multible dimple recipes to display on the index page
        public static List<DisplaySimpleRecipe> GetDisplaySimpleRecipes()
        {
            using (var db = new RecipeDBConnection())
            {
                DisplaySimpleRecipe simpleRecipe = new DisplaySimpleRecipe();
                var recipe = db.RECIPEs;

                List<DisplaySimpleRecipe> displayRecipes = new List<DisplaySimpleRecipe>() ;
                DisplaySimpleRecipe tmpDisplaySimpleRecipe;
                foreach(RECIPE item in recipe)
                {
                    tmpDisplaySimpleRecipe = new DisplaySimpleRecipe();
                    tmpDisplaySimpleRecipe.RecipeName = item.NAME;
                    tmpDisplaySimpleRecipe.ShortDescription = item.DESCRIPTION.Substring(0, item.DESCRIPTION.Length / 2);
                    tmpDisplaySimpleRecipe.ImagePAth = "DEFAULT_NOTHING.jpg";
                    displayRecipes.Add(tmpDisplaySimpleRecipe);
                    tmpDisplaySimpleRecipe = null;
                }

                return displayRecipes;


            }
        }

        public static FullRecipe GetFullRecipe(String recipeName)
        {
            using (var db = new RecipeDBConnection())
            {
                FullRecipe result = new FullRecipe();
                DbSet<RECIPE> recipes = db.RECIPEs;

                //getting the recipe data
                RECIPE recipe = null;
                foreach(var item in recipes) {
                    if(item.NAME == recipeName)
                    {
                        recipe = item;
                        break;
                    }
                }

                if (recipe == null)
                {
                    return null;
                }

                result.name = recipe.NAME;
                result.Description = recipe.DESCRIPTION;

                //Getting the comments for the recipe 
                List<comment> commentsForRecipe = new List<comment>();
                foreach(var item in db.comments)
                {
                    if(item.ID_RECIPE == recipe.ID_RECIPE)
                    {
                        commentsForRecipe.Add(item);
                    }
                }
                result.Comments = commentsForRecipe;

                //getting the ingredients for the recipe

                var iNGREDIENT_IN_RECIPEs = from item in db.INGREDIENT_IN_RECIPE
                                            join measurement in db.MEASUREMENT_UNIT on item.ID_MEASUREMENT equals measurement.ID_MEASUREMENT
                                            join ingredient in db.INGREDIENTs on item.ID_INGREDIENT equals ingredient.ID_INGREDIENT
                                            where item.ID_RECIPE == recipe.ID_RECIPE select item;

                List<DisplayIngredient> displayIngredients = new List<DisplayIngredient>();

                foreach(var item in iNGREDIENT_IN_RECIPEs)
                {
                        //TODO fix this shit
                    displayIngredients.Add(new DisplayIngredient(item.INGREDIENT.NAME,999,item.MEASUREMENT_UNIT.TEXT));
                }

                result.Ingredients = displayIngredients;
                return result;
            }

        }
        
    }
}