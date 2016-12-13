using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewingRecipes.Domain;
using BrewingRecipes.Data;

namespace BrewingRecipes.Service
{
    public class BrewerService
    {
        public List<IBrewer>  GetByName(string name)
        {
            using (var context = new BrewingRecipesContext())
            {
                return context.Brewers.AsNoTracking()
                    .Where(x => x.Name.Contains(name))
                    .Select(x =>
                    new Brewer
                    {
                        BrewerId = x.BrewerId,
                        Name = x.Name,
                        EmailAddress = x.EmailAddress
                    }).ToList().Cast<IBrewer>().ToList();
            }
        }

        public bool Add(IBrewer brewerData)
        {
            using (var context = new BrewingRecipesContext())
            {
                context.Brewers.Add(
                new BrewingRecipes.EntityFrameworkPersistenceModel.Brewer
                {
                    Name = brewerData.Name,
                    EmailAddress = brewerData.EmailAddress
                }
                );
                context.SaveChanges();
                return true;
            }

        }

        public void Delete(IBrewer brewerData)
        {
            using (var context = new BrewingRecipesContext())
            {
                var targetBrewer = context.Brewers.Find(brewerData.BrewerId);
                if (targetBrewer != null)
                    context.Brewers.Remove(targetBrewer);
                context.SaveChanges();
            }
        }
        

    }
}
