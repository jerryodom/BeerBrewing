using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
{
    /// <summary>
    /// Anything Fermentable - A sugar, a grain
    /// </summary>
    public interface IFermentable
    {
        double DiastaticPower { get; set; }
    }
}
