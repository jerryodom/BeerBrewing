using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewingRecipes.Data;

namespace DummyProject.Controllers
{
    public class HomeController : Controller
    {
        BrewingRecipesContext dataContext;
        public ActionResult Index()
        {
            var myBrewer = new BrewingRecipes.EntityFrameworkPersistenceModel.Brewer();
            myBrewer.Name = "Wayne";
            dataContext = new BrewingRecipesContext();
            dataContext.Brewer.Add(new BrewingRecipes.EntityFrameworkPersistenceModel.Brewer());
            dataContext.SaveChanges();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
