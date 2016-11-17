using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.Domain
{
    public class BrewDay
    {
        public int BrewDayId { get; set; }
        public BeerRecipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public Brewer Brewer { get; set; }
        public int BrewerId { get; set; }

    }
}
