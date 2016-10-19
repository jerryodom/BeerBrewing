using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
{
    /// <summary>
    /// IBitter - Anything added to cause bitterness.  Hops primarily.  Other herbs
    /// </summary>
    public interface IBitter : IIngredient
    {
        double BitteringFactor { get; set; }
        double BitterCalculationTime { get; set; }
    }

    public class Hops : IBitter
    {
        /// <summary>
        /// Represented in US ounces
        /// </summary>
        public double Amount
        {
            get;set;
        }

        /// <summary>
        /// Time in minutes.  Usually minutes boiled
        /// </summary>
        public double BitterCalculationTime
        {
            get;set;
        }
        /// <summary>
        /// This will be represented in alpha acid %.  15% for centennial for example
        /// </summary>
        public double BitteringFactor
        {
            get;set;
        }

        public string Name
        {get;set;
        }

        /// <summary>
        /// For version 1 apply the basic tinseth IBU calculation.  For version 2 this might need to be an injectable strategy to handle other non tinseth situations.
        /// </summary>
        /// <param name="targetRecipe"></param>
        /// <returns></returns>
        public double ApplyToRecipe(IRecipe targetRecipe)
        {
            double ibus = 0;
            if (targetRecipe.BatchVolume > 0)
            {
                ibus = Utilization(targetRecipe) * (this.Amount * (this.BitteringFactor / 100) * 7490) / targetRecipe.BatchVolume;
            }
            else
            {
                throw new InvalidOperationException("Recipe Batch Volume must be greater than zero to apply to recipe.");
            }
            return ibus;
        }

        /// <summary>
        /// assumes tinseth for now. later refactor a strategy to inject  forumulas
        /// </summary>
        /// <param name="targetRecipe"></param>
        /// <returns></returns>
        private double Utilization(IRecipe targetRecipe)
        {
            double utilization = 0;
            if (targetRecipe.BatchVolume > 0)
            {
                    double part1 = Math.Pow((double)0.000125, ((double)targetRecipe.GetEstimatedOriginalGravity() - (double)1));
                    double part2 = Math.Pow(2.72, (-0.04 * (double)this.BitterCalculationTime));
                utilization = ((double)1.65 * (double)part1) * ((double)1 - (double)part2) / (double)4.14;
                
            }
            return utilization;
        }

        public string IngredientDescription()
        {
            return "Name: " + this.Name + "<!>Bitter Factor: " + this.BitteringFactor + "<!>Amount: " + this.Amount;
        }
    }

}
