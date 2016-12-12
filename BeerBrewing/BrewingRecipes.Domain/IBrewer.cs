using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.Domain
{
    public interface IBrewer
    {
        int BrewerId { get; set; }
        string Name { get; set; }
        string EmailAddress { get; set; }

        ICollection<IRecipe> Recipes { get; set; }
    }
}
