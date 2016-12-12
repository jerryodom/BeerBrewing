using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewingRecipes.Service;
using BrewingRecipes.Domain;

namespace DummyProject.Controllers
{
    public class HomeController : Controller
    {
        BrewerService brewService = new BrewerService();
        public ActionResult Index()
        {

            var myBrewer = new BrewingRecipes.Domain.Brewer();
            myBrewer.Name = "Wayne";
            brewService.Add(myBrewer as IBrewer);
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
