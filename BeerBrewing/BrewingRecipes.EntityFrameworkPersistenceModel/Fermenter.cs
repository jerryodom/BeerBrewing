using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{
    public class Fermenter 
    {
        public int IngredientId { get; set; }
        public double Amount
        {
            get; set;
        }

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
