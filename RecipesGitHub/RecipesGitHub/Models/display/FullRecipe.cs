using RecipesGitHub.Controllers;
using RecipesGitHub.Models.display;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models
{
    public class FullRecipe
    {
        private String name;
        public FullRecipe()
        {
            this.Comments = new List<comment>();
            this.name = "Recipe name";
            this.Description = "The description goes here";
            this.Ingredients = new List<JsonIngredient>();
            this.ImagePath = "NO_IMAGE";

        }
        public FullRecipe(String name, String description, List<JsonIngredient> ingredients)
        {
            this.Comments = new List<comment>();
            this.name = name;
            this.Description = description;
            this.Ingredients = ingredients;
            this.ImagePath = "";
        }

        public String GetName()
        {
            return this.name;
        }

        public void SetName(String name)
        {
            this.name = name;
            String[] files = Directory.GetFiles(UploadController.IMAGE_PATH + "/" + name + "/");
            if (files.Length > 0)
            {
                this.ImagePath = "/img/" + "recipeImages/" + name + "/" + Path.GetFileName(files[0]);

            }
            else
            {
                this.ImagePath = "NO_IMAGE";
            }
        }

        public String ImagePath { get; set; }
        public List<comment> Comments { get; set; }
    
        public List<JsonIngredient> Ingredients { get; set; }
        public String Description { get; set; }


    }
}