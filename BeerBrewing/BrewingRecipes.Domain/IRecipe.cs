using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.Domain
{
    public interface IRecipe
    {
        string Name { get; set; }

        double BatchVolume { get; set; }
        /// <summary>
        /// Example 70%
        /// </summary>
        double TotalEfficiencyPercent { get; set; }

        double GetEstimatedOriginalGravity();

        double GetEstimatedFinalGravity();

        double GetEstimatedBitterness();

        ICollection<IIngredient> Ingredients { get; set; }
        ICollection<IFerment> Fermenters { get; set; }
        ICollection<IFermentable> Fermentables { get; set; }
        ICollection<IBitter> Bitters { get; set; }
        
        IStyle Style { get; set; }
        int RecipeId { get; set; }

        DateTime BrewDate { get; set; }
    }
}
