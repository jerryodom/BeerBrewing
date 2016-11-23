﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.EntityFrameworkPersistenceModel
{
    public class BeerRecipe
    {
        public string Name { get; set; }

        public double BatchVolume { get; set; }
        
        public double TotalEfficiencyPercent { get; set; }

        public int RecipeId { get; set; }

        public ICollection<Fermenter> Fermenters
        {
            get; set;
        }
        public ICollection<Fermentable> Fermentables
        {
            get; set;
        }
        public ICollection<Bitter> Bitters
        {
            get;set;
        }
    }
}
