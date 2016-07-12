using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using StrikeInfusionCalculation;

namespace StrikeInfusionCalculationTests
{
    [TestClass]
    public class StrikeInfusionCalculationTests
    {

        [TestMethod]
        public void StrikeInfusionCalculation_TemperatureFahrenheit_InitialStep_Passes()
        {
            ICalculateStrikeInfusionFactory myStrikeInfusionCalculation = new CalculateStrikeInfusionFactory();
            var strikeCalculator = myStrikeInfusionCalculation.GetCalculator(new CalculateStrikeInfusionStrikeTemperaturFahrenheiteOfWaterToAddStrategy());
            strikeCalculator.InitialMashTemperatureFahrenheit = 72;
            strikeCalculator.MashTunInfusionAdjustmentDegreesPerPound = .3;
            strikeCalculator.MashTunWeightInPounds = 30;
            strikeCalculator.StartingWaterVolumeInQuarts = 0;
            strikeCalculator.TargetStepTemperature = 145;
            strikeCalculator.WaterToAddInQuarts = 18;
            strikeCalculator.WeightOfGrainInPounds = 12;
            var initialStepTemperatureOfWaterToAdd = strikeCalculator.Calculate();

            Assert.AreEqual(154.73, Math.Round(initialStepTemperatureOfWaterToAdd, 2));
        }
    }
}
