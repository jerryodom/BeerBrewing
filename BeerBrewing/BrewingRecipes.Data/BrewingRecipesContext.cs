using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BrewingRecipes.Domain;

namespace BrewingRecipes.Data
{
    public class BrewingRecipesContext : DbContext
    {
        public BrewingRecipesContext() : base("name=BeerBrewingRecipes")
        {

        }

        public DbSet<Brewer> Brewer { get; set; }
        //public DbSet<BrewDay> BrewersBrewDays{ get; set;}
        public DbSet<BeerRecipe> BrewingRecipes { get; set; }
        public DbSet<Hops> Bitters { get; set; }
        //public DbSet<Yeast> BrewingRecipesYeasts { get; set; }
        //public DbSet<Fermentable> BrewingRecipesFermentables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BrewingRecipes");
            modelBuilder.Entity<Brewer>()
                .HasKey(p => p.BrewerId);
            modelBuilder.Entity<BeerRecipe>()
                .HasKey(p => p.RecipeId);
            //modelBuilder.Entity<Yeast>().HasKey(p => p.IngredientId);
            //modelBuilder.Entity<Fermentable>().HasKey(p => p.IngredientId);
            //modelBuilder.Entity<Hops>().HasKey(p => p.IngredientId).HasEntitySetName("Bitters");
            //modelBuilder.Entity<BeerRecipe>().HasMany(p => p.Bitters);

            base.OnModelCreating(modelBuilder);
        }
    }
}
