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
    [RoutePrefix("api/brewing")]
    public class BeerMathController : ApiController
    {
        /// <summary>
        /// Calculate alcohol by volume given starting and ending gravity.
        /// </summary>
        /// <param name="startingGravity">Starting Gravity in Original Gravity.  Ex:  1.051</param>
        /// <param name="endingGravity">Final Gravity in Original Gravity.  Ex:  1.011</param>
        /// <param name="temperatureFahrenheit">Temperature in Fahrenheit at Final Gravity reading.  Ex:  72F</param>
        /// <returns></returns>
        [Route("alcoholbyvolume/{startingGravity:double}/{endingGravity:double}/{temperatureFahrenheit:double}")]
        public AlcoholModel GetAlcoholByVolume(double startingGravity, double endingGravity, double temperatureFahrenheit)
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
