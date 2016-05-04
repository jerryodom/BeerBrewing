using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using CarbonationCalculation;

namespace CarbonationCalculationTests
{
    [TestClass]
    public class CarbonationCalculationTests
    {
        [TestMethod]
        public void CarbonationCalculation_Passes()
        {
            ICalculateCarbonationFactory carbonationFactory = new CalculateCarbonationFactory();
            var carbonationCalculator = carbonationFactory.GetCalculator(null);
            carbonationCalculator.BeerVolumeInGallons = 5;
            carbonationCalculator.BeerTemperatureInFahrenheit = 32;
            carbonationCalculator.DesiredCarbonationInVolumes = 3;
            carbonationCalculator.SetCarbonationType(new CarbonateUsingForcedPressureReturnsPsiStrategy());
            double carbonationPressureNeeded = carbonationCalculator.Calculate();
            Assert.AreEqual(12.92, Math.Round(carbonationPressureNeeded, 2));

            carbonationCalculator.SetCarbonationType(new CarbonateUsingDmeReturnsGramsStrategy());
            var gramsOfDmeNeeded = carbonationCalculator.Calculate();
            Assert.AreEqual(151.10, Math.Round(gramsOfDmeNeeded, 2));

        }
    }
}
