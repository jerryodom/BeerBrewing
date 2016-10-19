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
        public IEnumerable<IFerment> GetFermenters()
        {
            var myFermenter = new List<IFerment>();
            foreach (var ingredient in ingredientsList.Where(p => (p as IFerment) != null))
            {
                myFermenter.Add(ingredient as IFerment);
            }
            return myFermenter.AsEnumerable<IFerment>();
        }
        public IEnumerable<IBitter> GetBitters()
        {
            var myBitters = new List<IBitter>();
            foreach (var ingredient in ingredientsList.Where(p => (p as IBitter) != null))
            {
                myBitters.Add(ingredient as IBitter);
            }
            return myBitters.AsEnumerable<IBitter>();
        }
        public IEnumerable<IFermentable> GetFermentables()
        {
            var myFermentables = new List<IFermentable>();
            foreach (var ingredient in ingredientsList.Where(p => (p as IFermentable) != null))
            {
                myFermentables.Add(ingredient as IFermentable);
            }
            return myFermentables.AsEnumerable<IFermentable>();
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
         public double GetEstimatedBitterness()
        {
            if (this.BatchVolume == 0)
            {
                throw new InvalidOperationException("Can't calculate bitterness when BatchVolume is 0");
            }
            double potentialBitternessUnits = 0;
            foreach (var bitter in this.GetBitters())
            {
                potentialBitternessUnits += (bitter as IBitter).ApplyToRecipe(this);
            }
            return potentialBitternessUnits;

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

        double GetEstimatedBitterness();

        IList<IIngredient> IngredientsList { get; set; }
        

        IEnumerable<IFerment> GetFermenters();

        IEnumerable<IBitter> GetBitters();

        IEnumerable<IFermentable> GetFermentables();

        IStyle Style { get; set; }

    }
}
