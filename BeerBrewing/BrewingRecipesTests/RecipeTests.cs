﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrewingRecipes.Domain;
using System.Linq;

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
            myRecipe.BatchVolume = 6.5;
            myRecipe.Name = "My Beer Name";
            myRecipe.TotalEfficiencyPercent = 70;
            myRecipe.Style = new Style();
            IngredientFactory myIngredientFactory = new IngredientFactory();
            myRecipe.Ingredients.Add(myIngredientFactory.GetIngredient(IngredientType.Fermentable));
            myRecipe.BatchVolume = 6.5;
            Assert.AreEqual(1, myRecipe.Ingredients.Count);
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
            myRecipe.Ingredients.Add(ingredient);
            //adding bitters is just a test for my sanity in querying interfaces and dealing with Covariance
            //note it will be repeated on the IBU calculation as the fermentable power impacts bitterness
            ingredient = myIngredientFactory.GetIngredient(IngredientType.BitterSeason);
            ingredient.Amount = 1.5;
            myRecipe.Ingredients.Add(ingredient);
            myRecipe.BatchVolume = 6.5;
            myRecipe.TotalEfficiencyPercent = 70;
            var og = myRecipe.GetEstimatedOriginalGravity();
            Assert.AreEqual(myRecipe.Fermentables.Count, 1);
            Assert.AreEqual(Math.Round(og, 3), 1.043);
        }


        [TestMethod]
        public void ApplyBitterToRecipe()
        {
            RecipeFactory myFactory = new RecipeFactory();
            IRecipe myRecipe = myFactory.GetRecipe(RecipeTypes.Beer);
            IngredientFactory myIngredientFactory = new IngredientFactory();
            var ingredient = myIngredientFactory.GetIngredient(IngredientType.Fermentable);
            ingredient.Amount = 10;
            (ingredient as IFermentable).DiastaticPower = 1.04;
            myRecipe.Ingredients.Add(ingredient);
            //adding bitters is just a test for my sanity in querying interfaces and dealing with Covariance
            //note it will be repeated on the IBU calculation as the fermentable power impacts bitterness
            ingredient = myIngredientFactory.GetIngredient(IngredientType.BitterSeason);
            ingredient.Amount = 1.5;
            (ingredient as IBitter).BitteringFactor = 15;
            (ingredient as IBitter).BitterCalculationTime = 60;
            myRecipe.Ingredients.Add(ingredient);
            myRecipe.BatchVolume = 6.5;
            myRecipe.TotalEfficiencyPercent = 70;
            var ibus = myRecipe.GetEstimatedBitterness();
            Assert.AreEqual(myRecipe.Bitters.Count, 1);
            //May need to check formula.  BeerSmith usually is a little higher.  BeerSmith has been known to tweak their forumulas though.
            Assert.AreEqual(63.81, Math.Round(ibus, 2));
        }


        [TestMethod]
        public void ApplyFermenterToRecipe()
        {
            RecipeFactory myFactory = new RecipeFactory();
            IRecipe myRecipe = myFactory.GetRecipe(RecipeTypes.Beer);
            IngredientFactory myIngredientFactory = new IngredientFactory();
            var ingredient = myIngredientFactory.GetIngredient(IngredientType.Fermentable);
            ingredient.Amount = 10;
            (ingredient as IFermentable).DiastaticPower = 1.04;
            myRecipe.Ingredients.Add(ingredient);
            myRecipe.BatchVolume = 6.5;
            myRecipe.TotalEfficiencyPercent = 70;
            var og = myRecipe.GetEstimatedOriginalGravity();
            Assert.AreEqual(myRecipe.Fermentables.Count, 1);
            Assert.AreEqual(Math.Round(og, 3), 1.043);
            ingredient = myIngredientFactory.GetIngredient(IngredientType.Fermenter);
            (ingredient as IFerment).PitchType = FermenterPitchType.Dry;
            (ingredient as IFerment).Attenuation = 75;
            myRecipe.Ingredients.Add(ingredient);
            var fg = myRecipe.GetEstimatedFinalGravity();
            Assert.AreEqual(Math.Round(fg, 3), 1.011);

        }
    }
}
