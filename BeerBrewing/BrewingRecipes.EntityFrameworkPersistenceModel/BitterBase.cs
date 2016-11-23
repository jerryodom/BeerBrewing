using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{
public class BitterBase
    {

        public int BrewerId { get; set; }

        public Brewer Brewer { get; set; }
        public int IngredientId { get; set; }
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
