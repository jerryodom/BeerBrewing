using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{
public class Bitter
    {
        public int IngredientId { get; set; }
        /// <summary>
        /// Represented in US ounces
        /// </summary>
        public double Amount
        {
            get; set;
        }

        /// <summary>
        /// Time in minutes.  Usually minutes boiled
        /// </summary>
        public double BitterCalculationTime
        {
            get; set;
        }
        /// <summary>
        /// This will be represented in alpha acid %.  15% for centennial for example
        /// </summary>
        public double BitteringFactor
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
    }
}
