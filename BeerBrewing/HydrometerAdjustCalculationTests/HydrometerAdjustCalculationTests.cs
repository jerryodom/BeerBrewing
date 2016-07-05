using System;
using Core;
using HydrometerAdjustCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HydrometerAdjustCalculationTests
{
    [TestClass]
    public class HydrometerAdjustCalculationTests
    {
        [TestMethod]
        public void HydrometerAdjustForTemperatureTest_Passes()
        {
            ICalculateHydrometerAdjustFactory adjustedHydrometerReadingCalculationFactory = new CalculateHydrometerAdjustFactory();
            var calculator = adjustedHydrometerReadingCalculationFactory.GetCalculator(new HydrometerAdjustStrategy());
            calculator.TemperatureInFahrenheit = 72;
            calculator.CalibrationTemperatureInFahrenheit = 60;
            calculator.MeasuredSpecificGravity = 1.05;
            var finalVolume = calculator.Calculate();
            Assert.AreEqual(Math.Round(finalVolume, 4), 1.0513);
        }
    }
}
