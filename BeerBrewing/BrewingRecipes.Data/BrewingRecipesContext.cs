using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BrewingRecipes.EntityFrameworkPersistenceModel;

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
        public DbSet<Bitter> Bitters { get; set; }
        public DbSet<Fermenter> BrewingRecipesYeasts { get; set; }
        public DbSet<Fermentable> BrewingRecipesFermentables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BrewingRecipes");
            modelBuilder.Entity<Brewer>()
                .HasKey(p => p.BrewerId);
            modelBuilder.Entity<Fermenter>().HasKey(p => p.IngredientId);
            modelBuilder.Entity<Fermentable>().HasKey(p => p.IngredientId);
            modelBuilder.Entity<Bitter>().HasKey(p => p.IngredientId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
