using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BrewingRecipes.EntityFrameworkPersistenceModel;
using System.Data.Entity.ModelConfiguration;

namespace BrewingRecipes.Data
{
    public class BrewingRecipesContext : DbContext
    {
        public BrewingRecipesContext() : base("name=BeerBrewingRecipes")
        {

        }

        public DbSet<Brewer> Brewers { get; set; }
        //public DbSet<BrewDay> BrewersBrewDays { get; set; }
        public DbSet<BeerRecipe> BrewingRecipes { get; set; }
        public DbSet<Bitter> Bitters { get; set; }
        public DbSet<Fermenter> BrewingRecipesYeasts { get; set; }
        public DbSet<FermenterBase> BaseBrewingRecipesYeasts { get; set; }
        public DbSet<Fermentable> BrewingRecipesFermentables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BrewingRecipes");
            modelBuilder.Configurations.Add(new BrewerConfiguration());
            modelBuilder.Configurations.Add(new BeerRecipeConfiguration());
            modelBuilder.Configurations.Add(new FermentableConfiguration());
            modelBuilder.Configurations.Add(new FermenterConfiguration());
            modelBuilder.Configurations.Add(new FermenterBaseConfiguration());
            modelBuilder.Configurations.Add(new BitterConfiguration());
            modelBuilder.Configurations.Add(new FermentableBaseConfiguration());
            modelBuilder.Configurations.Add(new BitterBaseConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class BeerRecipeConfiguration : EntityTypeConfiguration<BeerRecipe>
    {
        public BeerRecipeConfiguration()
        {
            ToTable("BeerRecipes");
            HasKey(f => f.RecipeId);
            Property(r => r.Name).IsRequired().HasMaxLength(100);
            Property(r => r.BatchVolume).IsRequired();
            Property(r => r.TotalEfficiencyPercent).IsRequired();
            HasOptional(p => p.Bitters).WithRequired().WillCascadeOnDelete(true);
            HasOptional(p => p.Fermentables).WithRequired().WillCascadeOnDelete(true);
            HasOptional(p => p.Fermenters).WithRequired().WillCascadeOnDelete(true);
        }
    }

    public class BrewerConfiguration : EntityTypeConfiguration<Brewer>
    {
        public BrewerConfiguration()
        {
            ToTable("Brewers");
            HasKey(b => b.BrewerId);
        }
    }

    public class BitterConfiguration : EntityTypeConfiguration<Bitter>
    {
        public BitterConfiguration()
        {
            ToTable("Bitters");
            HasKey(f => f.IngredientId);

        }
    }
    public class FermentableConfiguration : EntityTypeConfiguration<Fermentable>
    {
        public FermentableConfiguration()
        {
            ToTable("Fermentables");
            HasKey(f => f.IngredientId);

        }
    }
    public class FermenterConfiguration : EntityTypeConfiguration<Fermenter>
    {
        public FermenterConfiguration()
        {
            ToTable("Fermenters");
            HasKey(f => f.IngredientId);
            HasRequired(p => p.BaseIngredient);


        }
    }
    public class FermenterBaseConfiguration : EntityTypeConfiguration<FermenterBase>
    {
        public FermenterBaseConfiguration()
        {
            ToTable("FermentersBase");
            HasKey(f => f.IngredientId);
            HasRequired(b => b.Brewer).WithMany(z => z.BaseYeast).WillCascadeOnDelete(true);


        }
    }
    public class FermentableBaseConfiguration : EntityTypeConfiguration<FermentableBase>
    {
        public FermentableBaseConfiguration()
        {
            ToTable("FermentablesBase");
            HasKey(f => f.IngredientId);
            HasRequired(b => b.Brewer).WithMany(z => z.BaseFermentables).WillCascadeOnDelete(true);


        }
    }
    public class BitterBaseConfiguration : EntityTypeConfiguration<BitterBase>
    {
        public BitterBaseConfiguration()
        {
            ToTable("BittersBase");
            HasKey(f => f.IngredientId);
            HasRequired(b => b.Brewer).WithMany(z => z.BaseBitters).WillCascadeOnDelete(true);


        }
    }

  
}
