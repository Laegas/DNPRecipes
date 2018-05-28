using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesGitHub.Models.display
{
    public class DisplayIngredient
    {
        public DisplayIngredient(String ingredientName, int amount, String measurementUnit)
        {
            this.IngredientName = ingredientName;
            this.Amount = amount;
            this.MeasurementUnit = measurementUnit;
        }

        public String IngredientName { get; set; }
        public int Amount { get; set; }
        public String MeasurementUnit { get; set; }

    }
}