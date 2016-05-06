using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using WaterNeededExtractCalculation;

namespace WaterNeededExtractCalculationTests
{
    [TestClass]
    public class WaterNeededExtractCalculationTests
    {
        [TestMethod]
        public void WaterNeededExtractCalculation_Passes()
        {
            ICalculateWaterNeededExtractFactory waterNeededFactory = new CalculateWaterNeededExtractFactory();
            ICalculateWaterNeededExtract waterNeededExtractCalculator = waterNeededFactory.GetCalculator(new CalculateWaterNeededExtractStrategy());
            waterNeededExtractCalculator.BoilTimeInMinutes = 60;
            waterNeededExtractCalculator.DesiredFinalVolumeInGallons = 6;
            waterNeededExtractCalculator.EvaporationRatePercent = 12.79;
            waterNeededExtractCalculator.LossToTrubInGallons = 0.5;
            waterNeededExtractCalculator.MashWaterVolumeInQuarts = 16;
            waterNeededExtractCalculator.TopUpWaterInGallons = 0;
            waterNeededExtractCalculator.GetCoolingLossInGallons();
            var totalWaterNeeded = waterNeededExtractCalculator.Calculate();
            Assert.AreEqual(7.72, totalWaterNeeded);

        }
    }
}
