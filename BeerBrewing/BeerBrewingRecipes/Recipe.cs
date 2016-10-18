using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes
{

    public enum RecipeTypes
    {
        Beer,
        Mead,
        Other
    }
    public class RecipeFactory
    {
        public IRecipe GetRecipe(RecipeTypes recipeType)
        {
            if(recipeType == RecipeTypes.Beer)
            {
                return new BeerRecipe();
            }
            else
            {
                return new Recipe();
            }
        }
    }


    public class Recipe : IRecipe
    {
        public IEnumerable<IIngredient> GetFermenters()
        {
            return ingredientsList.Where(p => (p as IFerment) != null).AsEnumerable();
        }
        public IEnumerable<IIngredient> GetBitters()
        {
            return ingredientsList.Where(p => (p as IBitter) != null).AsEnumerable();
        }
        public IEnumerable<IIngredient> GetFermentables()
        {
            return ingredientsList.Where(p => (p as IFermentable) != null).AsEnumerable();
        }

        public double GetEstimatedOriginalGravity()
        {
            if(this.BatchVolume == 0)
            {
                throw new InvalidOperationException("Can't calculate gravity when BatchVolume is 0");
            }
            double potentialGravityUnits = 0;
            foreach(var fermentable in this.GetFermentables())
            {
                potentialGravityUnits += (fermentable as IFermentable).ApplyToRecipe(this);
            }
            return 1 + (potentialGravityUnits / this.BatchVolume / 1000);
        }

        public double TotalEfficiencyPercent { get; set; }

        public IStyle Style { get; set; }

        public string Name
        {
            get;set;
        }
        public double BatchVolume { get; set; }

        private List<IIngredient> ingredientsList = new List<IIngredient>();

        public IList<IIngredient> IngredientsList
        {
            get{
                return ingredientsList;
            }
            set
            {
                ingredientsList = value.ToList();
            }
        }
    }

    public interface IRecipe
    {
        string Name { get; set; }

        double BatchVolume { get; set; }
        /// <summary>
        /// Example 70%
        /// </summary>
        double TotalEfficiencyPercent { get; set; }

        double GetEstimatedOriginalGravity();

        IList<IIngredient> IngredientsList { get; set; }
        

        IEnumerable<IIngredient> GetFermenters();

        IEnumerable<IIngredient> GetBitters();

        IEnumerable<IIngredient> GetFermentables();

        IStyle Style { get; set; }

    }
}
