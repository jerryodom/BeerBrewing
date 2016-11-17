using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BrewingRecipes.Domain
{
    public class Yeast : IFerment
    {
        public int IngredientId { get; set; }
        public double Amount
        {
            get;set;
        }

        public double Attenuation
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public FermenterPitchType PitchType
        {
            get; set;
        }

        public double ApplyToRecipe(IRecipe targetRecipe)
        {
            var og = targetRecipe.GetEstimatedOriginalGravity();
            var forReturn = ((og - 1) - ((og - 1) * this.Attenuation / 100)) + 1;
            return forReturn;
        }

        public string IngredientDescription()
        {
            throw new NotImplementedException();
        }
    }
}
