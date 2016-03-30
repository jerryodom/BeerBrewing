using System;
using Core;
using BoilOffCalculaton;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VolumeShrinkageFromCoolingCalculation
{
    [TestClass]
    public class VolumeShrinkageFromCoolingCalculationTests
    {
        [TestMethod]
        public void CalculateVolumeShrinkageFromCooling_Passes()
        {

            ICalculateBoilOffFactory boilCalculatorFactory = new CalculateBoilOffFactory();
            ICalculateBoilOff boilCalculator = boilCalculatorFactory.GetCalculator(null);
            boilCalculator.BoilTimeInMinutes = 60;
            boilCalculator.StartingVolumeInGallons = 5;
            boilCalculator.EvaporationRateInPercent = 4;
            var boiledOffVolumeInGalls = (boilCalculator as Calculator).Calculate();
            Assert.AreEqual(0.2, boiledOffVolumeInGalls);

            ICalculateVolumeShrinkageFromCoolingFactory calculatorFactory = new CalculateVolumeShrinkageFromCoolingFactory();
            ICalculateVolumeShrinkageFromCooling calculator = calculatorFactory.GetCalculator(null);
            calculator.VolumeAfterBoilOff =  5 - boiledOffVolumeInGalls;
            calculator.StartingVolumeInGallons = 5;
            calculator.CoolingLossInPercent = 4;
            var shrinkageFromCoolingInGals = (calculator as Calculator).Calculate();
            Assert.AreEqual(0.192, shrinkageFromCoolingInGals);
        }
    }
}
