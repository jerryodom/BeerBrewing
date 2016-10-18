using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
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
                default:
                    throw new NotImplementedException("need to finish implementing ingredients");
            }
        }
    }

    public interface IIngredient
    {
        string Name { get; set; }

        double Amount { get; set; }
        double ApplyToRecipe(IRecipe targetRecipe);
    }
    
}
