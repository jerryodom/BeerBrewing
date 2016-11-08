using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
{
    public abstract class Brewer
    {
        IEnumerable<BrewDay> BrewDays { get; set; }

    } 
}