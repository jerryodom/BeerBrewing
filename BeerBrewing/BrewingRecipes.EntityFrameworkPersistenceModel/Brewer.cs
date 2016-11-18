using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{
    public class Brewer
    {
        public int BrewerId { get; set; }
        public string Name { get; set; }
        private ICollection<BeerRecipe> _recipes;
        public ICollection<BeerRecipe> Recipes
        {
            get
            {
                return _recipes;
            }

            set
            {
                _recipes = value;
            }
        }
    }
}
