using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{
    public class Fermenter : IHistory
    {
        public BeerRecipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int BaseIngredientId { get; set; }
        
        public FermenterBase BaseIngredient { get; set; }
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
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        public bool IsDirty { get; set; }
    }
}
