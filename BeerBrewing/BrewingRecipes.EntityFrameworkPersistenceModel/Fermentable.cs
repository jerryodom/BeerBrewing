using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{
    public class Fermentable : IHistory
    {
        public BeerRecipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }


        public int BaseIngredientId { get; set; }

        public FermentableBase BaseIngredient { get; set; }
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
            get; set;
        }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public bool IsDirty { get; set; }

    }
}
