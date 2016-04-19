using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using IbuCalculation;

namespace IbuCalculationTests
{
    [TestClass]
    public class IbuCalculationTests
    {
        [TestMethod]
        public void IbuCalculationTest_Tinseth_Passes()
        {
            ICalculateIbuFactory myIbuFactory = new CalculateIbuFactory();
            var ibuCalculator = myIbuFactory.GetCalculator();
            ibuCalculator.SetIbuType(new CalculateTinsethIbuStrategy());
            ibuCalculator.AlphaAcids = 6.4;
            ibuCalculator.HopeQuantityInOunces = 1.5;
            ibuCalculator.BatchOriginalGravity = 1.05;
            ibuCalculator.BatchVolumeInGallons = 5;
            ibuCalculator.BoilTimeInMinutes = 45;
            ibuCalculator.BoilVolumeInGallons = 6.5;
            var tinsethIbus = (ibuCalculator as Calculator).Calculate();

            Assert.AreEqual(30.37, Math.Round(tinsethIbus,2));

        }
    }
}
