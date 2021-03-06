﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.Domain
{
    public enum IngredientType
    {
        Fermenter,
        Fermentable,
        BitterSeason,
        FlavorSeason,
        AromaSeason,
        DrySeason
    }
    public class IngredientFactory
    {
        public IIngredient GetIngredient(IngredientType ingredientType)
        {
            switch (ingredientType)
            {
                case IngredientType.Fermentable:
                    return new Fermentable();
                case IngredientType.BitterSeason:
                    return new Hops();
                case IngredientType.Fermenter:
                    return new Yeast();
                default:
                    throw new NotImplementedException("need to finish implementing ingredients");
            }
        }
    }

    public interface IIngredient
    {
        int IngredientId { get; set; }
        string Name { get; set; }

        double Amount { get; set; }
        double ApplyToRecipe(IRecipe targetRecipe);

        string IngredientDescription();
    }
    
}
