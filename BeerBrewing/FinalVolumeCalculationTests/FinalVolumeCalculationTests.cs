using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalVolumeCalculation;
using Core;

namespace FinalVolumeCalculationTests
{
    [TestClass]
    public class FinalVolumeCalculationTests
    {
        [TestMethod]
        public void FinalVolume_CalculationTest()
        {
            ICalculateBoilOffFactory volumeCalculationFactory = new CalculateBoilOffFactory();
            var calculator = volumeCalculationFactory.GetCalculator(null);
            //possibly should abstract this out further in to a Filter in case people want different parameters in boil off calculation.
            calculator.BoilOffInGallons = .2;
            calculator.LossFromCoolingShrinkageInGallons = .192;
            calculator.StartingVolumeInGallons = 5;
            var finalVolume = (calculator as Calculator).Calculate();
            Assert.AreEqual(finalVolume, 4.608);

        }
    }
}
