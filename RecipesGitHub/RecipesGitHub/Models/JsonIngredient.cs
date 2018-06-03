using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models
{
    public class JsonIngredient
    {
        public JsonIngredient()
        {

        }
        public JsonIngredient(String ingredient, double amount, String unit)
        {
            this.ingredient = ingredient;
            this.amount = amount;
            this.unit = unit;
        }
        public String ingredient { get; set; }
        public double amount{ get; set; }
        public String unit { get; set; }

    }
}