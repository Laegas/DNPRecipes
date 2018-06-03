using RecipesGitHub.Models.display;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models.DAO
{
    public class RecipeDAO
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
                var recipe = db.RECIPEs;

                List<DisplaySimpleRecipe> displayRecipes = new List<DisplaySimpleRecipe>() ;
                DisplaySimpleRecipe tmpDisplaySimpleRecipe;
                foreach(RECIPE item in recipe)
                {
                    String recipeNme = item.NAME;
                    String shortDescription = item.DESCRIPTION;
                    tmpDisplaySimpleRecipe = new DisplaySimpleRecipe(recipeNme,shortDescription);
                    displayRecipes.Add(tmpDisplaySimpleRecipe);
                    tmpDisplaySimpleRecipe = null;
                }

                return displayRecipes;


            }
        }

        /**
         * A method for getting a full recipe from the database, 
         * the main purpose of this is to display the full recipe on the seerecipe site
         */
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

                result.SetName(recipe.NAME);
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

                List<JsonIngredient> displayIngredients = new List<JsonIngredient>();

                foreach(var item in iNGREDIENT_IN_RECIPEs)
                {
                    displayIngredients.Add(new JsonIngredient(item.INGREDIENT.NAME,999,item.MEASUREMENT_UNIT.TEXT));
                }

                result.Ingredients = displayIngredients;
                return result;
            }

        }
        
        /**
         * A method for uploading a Recipe object to the database.
         */
        public static bool CreateRecipe(FullRecipe fullRecipe)
        {
            using(var db = new RecipeDBConnection())
            {
                RECIPE tmpRECIPE = new RECIPE(fullRecipe.GetName(), fullRecipe.Description);
                db.RECIPEs.Add(tmpRECIPE);
                foreach(var ingredient_in_recipe in fullRecipe.Ingredients)
                {
                    db.INGREDIENT_IN_RECIPE.Add(new INGREDIENT_IN_RECIPE(ingredient_in_recipe.amount,ingredient_in_recipe.unit,(int)tmpRECIPE.ID_RECIPE));
                }

                db.SaveChanges();
            }

            return false;
            
        }
    }
}