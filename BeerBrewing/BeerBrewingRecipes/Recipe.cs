using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
{
    public abstract class Recipe
    {
        public IEnumerable<IFerment> Fermenters { get; set; }
        public IEnumerable<IBitter> Bittering { get; set; }
        public IEnumerable<IFermentable> Fermentables { get; set; }
    }
}
