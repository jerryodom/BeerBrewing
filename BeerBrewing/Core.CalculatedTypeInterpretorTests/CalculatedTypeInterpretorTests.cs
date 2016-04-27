using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.CalculatedTypeInterpretor;
using Core;
using IbuCalculation;

namespace Core.CalculatedTypeInterpretorTests
{
    [TestClass]
    public class CalculatedTypeInterpretorTests
    {
        [TestMethod]
        public void Interpret_OriginalGravity_To_Brix_Wrong_Type_Causes_Exception()
        {
            ICalculateIbu calculator = new IbuCalculation.IbuCalculation();
            calculator.AlphaAcids = 10;
            calculator.BatchOriginalGravity = 1.05;
            calculator.BatchVolumeInGallons = 5;
            calculator.BoilTimeInMinutes = 60;
            calculator.BoilVolumeInGallons = 6;
            calculator.HopeQuantityInOunces = 1;
            OriginalGravityToBrixCalculatedTypeInterpretor interpretor = new OriginalGravityToBrixCalculatedTypeInterpretor();
            try {
                var brixValue = interpretor.Interpret((calculator as Calculator));
            }
            catch (Exception exception) {
                Assert.IsInstanceOfType(exception, typeof(InvalidOperationException));
            }
             
        }
    }
}
