using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrewingRecipes;

namespace BrewingRecipesTests
{
    [TestClass]
    public class RecipeTests
    {
        //create recipe
        //set volume and name
        //set style
        //set brewer
        //name
        //hops
        //grain
        //yeast
        //water
        //equipment
        [TestMethod]
        public void CreateNewRecipe()
        {
            RecipeFactory myFactory = new RecipeFactory();
            IRecipe myRecipe = myFactory.GetRecipe(RecipeTypes.Beer);
            IngredientFactory myIngredientFactory = new IngredientFactory();
            myRecipe.IngredientsList.Add(myIngredientFactory.GetIngredient(IngredientType.Fermentable));
            myRecipe.BatchVolume = 6.5;
            Assert.AreEqual(1, myRecipe.IngredientsList.Count);
        }


        [TestMethod]
        public void ApplyFermentableToRecipe()
        {
            RecipeFactory myFactory = new RecipeFactory();
            IRecipe myRecipe = myFactory.GetRecipe(RecipeTypes.Beer);
            IngredientFactory myIngredientFactory = new IngredientFactory();
            var ingredient = myIngredientFactory.GetIngredient(IngredientType.Fermentable);
            ingredient.Amount = 10;
            (ingredient as IFermentable).DiastaticPower = 1.04;
            myRecipe.IngredientsList.Add(ingredient);
            //adding bitters is just a test for my sanity in querying interfaces and dealing with Covariance
            ingredient = myIngredientFactory.GetIngredient(IngredientType.BitterSeason);
            ingredient.Amount = 10;
            myRecipe.IngredientsList.Add(ingredient);
            myRecipe.BatchVolume = 6.5;
            myRecipe.TotalEfficiencyPercent = 70;
            var og = myRecipe.GetEstimatedOriginalGravity();
            Assert.AreEqual(Math.Round(og, 3), 1.043);
        }
    }
}
