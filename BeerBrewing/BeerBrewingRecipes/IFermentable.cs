using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
{
    /// <summary>
    /// Anything Fermentable - A sugar, a grain
    /// </summary>
    public interface IFermentable : IIngredient
    {
        double DiastaticPower { get; set; }
    }

    public class Fermentable : IFermentable
    {
        /// <summary>
        /// Will be stored in pounds by default
        /// </summary>
        public double Amount
        {
            get; set;
        }
        /// <summary>
        /// Will be represented in specific gravity by default
        /// </summary>
        public double DiastaticPower
        {
            get; set;
        }

        public string Name
        {
            get;set;
        }

        public double ApplyToRecipe(IRecipe targetRecipe)
        {
            return ((this.DiastaticPower - 1) * 1000 * this.Amount) * targetRecipe.TotalEfficiencyPercent / 100;
        }
    }

}
