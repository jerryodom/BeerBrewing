using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
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

        double GetEstimatedBitterness();

        IList<IIngredient> IngredientsList { get; set; }


        IEnumerable<IFerment> GetFermenters();

        IEnumerable<IBitter> GetBitters();

        IEnumerable<IFermentable> GetFermentables();

        IStyle Style { get; set; }
    }
}
