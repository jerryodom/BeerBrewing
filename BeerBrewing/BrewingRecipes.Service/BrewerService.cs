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

        private BrewingRecipesContext context;

        public BrewerService()
        {
            context = new BrewingRecipesContext();
        }
        public List<IBrewer>  GetByName(string name)
        {
                return context.Brewers
                    .Where(x => x.Name.Contains(name))
                    .Select(x =>
                    new Brewer
                    {
                        BrewerId = x.BrewerId,
                        Name = x.Name,
                        EmailAddress = x.EmailAddress
                    }).ToList().Cast<IBrewer>().ToList();
        }

        public void Add(IBrewer brewerData)
        {
            context.Brewers.Add(
                new BrewingRecipes.EntityFrameworkPersistenceModel.Brewer
                {
                    Name = brewerData.Name,
                    EmailAddress = brewerData.EmailAddress
                }
                );
            context.SaveChanges();

        }

    }
}
