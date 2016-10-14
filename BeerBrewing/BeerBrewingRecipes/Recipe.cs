using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
{
    public abstract class Recipe
    {
        public IEnumerable<IIngredient> IngredientsList { get; set; }
        public IEnumerable<IFerment> Fermenters { get;  }
        public IEnumerable<IBitter> Bittering { get;  }
        public IEnumerable<IFermentable> Fermentables { get;  }

        public IStyle Style { get; set; }
    }

    public interface IRecipe
    {
        string Name { get; set; }

        IEnumerable<IIngredient> IngredientsList { get; set; }

        IStyle Style { get; set; }

    }
}
