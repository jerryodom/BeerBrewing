using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{

    public class FermenterBase
    {
        public int IngredientId { get; set; }
        public int BrewerId { get; set; }

        public Brewer Brewer { get; set; }

        public double Attenuation
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

    }
}
