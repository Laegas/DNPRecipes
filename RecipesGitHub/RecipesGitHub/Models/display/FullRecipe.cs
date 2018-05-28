using RecipesGitHub.Models.display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models
{
    public class FullRecipe
    {
        public FullRecipe()
        {
            this.Comments = new List<comment>();
            this.name = "Recipe name";
            this.Description = "The description goes here";
            this.Ingredients = new List<DisplayIngredient>();
        }

        public List<comment> Comments { get; set; }
        public String name { get; set; }
        public List<DisplayIngredient> Ingredients { get; set; }
        public String Description { get; set; }


    }
}