using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeerBrewingApi.Models;
using Core;
using AlcoholCalculation;
namespace BeerBrewingApi.Controllers
{
    public class BeerMathController : ApiController
    {
        [Route("alcohol/{startingGravity}/{endingGravity}/{temperatureFahrenheit}")]
        public AlcoholModel GetAlcohol(double startingGravity, double endingGravity, double temperatureFahrenheit)
        {
            ICalculateAlcoholFactory alcoholFactory = new CalculateAlcoholFactory();
            var alcoholCalculator = alcoholFactory.GetCalculator(new AlcoholByVolumeStrategy());
            alcoholCalculator.StartingGravity = startingGravity;
            alcoholCalculator.EndingGravity = endingGravity;
            AlcoholModel model = new AlcoholModel();
            model.AlcoholByVolume = alcoholCalculator.Calculate();
            return model;
        }
    }
}
