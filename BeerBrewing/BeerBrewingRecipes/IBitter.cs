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
    }

    public class Hops : IBitter
    {
        public double Amount
        {
            get;set;
        }

        public double BitteringFactor
        {
            get;set;
        }

        public string Name
        {get;set;
        }

        public double ApplyToRecipe(IRecipe targetRecipe)
        {
            throw new NotImplementedException();
        }
    }

}
