using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{
    public class FermentableBase
    {
        public int IngredientId { get; set; }
        public int BrewerId { get; set; }

        public Brewer Brewer { get; set; }
        /// <summary>
        /// Will be stored in pounds by default
        /// </summary>
        /// <summary>
        /// Will be represented in specific gravity by default
        /// </summary>
        public double DiastaticPower
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

    }
}
