using RecipesGitHub.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models.display
{
    public class DisplaySimpleRecipe
    {

        public DisplaySimpleRecipe(String recipeName, String shortDescription)
        {
            this.RecipeName = recipeName;
            this.ShortDescription = shortDescription;
            String[] files = Directory.GetFiles(UploadController.IMAGE_PATH + "/" + RecipeName + "/");
            if(files.Length > 0)
            {
                this.ImagePath = "/img/recipeImages/" + this.RecipeName + "/" + Path.GetFileName(files[0]);

            }
            else
            {
                this.ImagePath = "NO_IMAGE";
            }

        }

        public String RecipeName { get; set; }
        public String ShortDescription { get; set; }
        public String ImagePath { get; set; }


    }
}