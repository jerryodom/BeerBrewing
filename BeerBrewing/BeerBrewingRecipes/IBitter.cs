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
    public interface IBitter
    {
        double BitteringFactor { get; set; }
    }
}
