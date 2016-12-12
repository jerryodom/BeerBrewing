using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.Domain
{
    public class Brewer : IBrewer
    {
        public int BrewerId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        private ICollection<IRecipe> _recipes;
        public ICollection<IRecipe> Recipes
        {
            get
            {
                return _recipes;
            }

            set
            {
                _recipes = value;
            }
        }
    } 
}