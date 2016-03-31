using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalGravityCalculation;
using Core;

namespace FinalGravityCalculationTests
{
    [TestClass]
    public class FinalGravityCalculationTests
    {
        [TestMethod]
        public void FinalGravityCalculation_Passes()
        {
            ICalculateFinalGravityFactory finalGravityFactory = new CalculateFinalGravityFactory();
            ICalculateFinalGravity finalGravityCalculator = finalGravityFactory.GetCalculator(null);
            finalGravityCalculator.StartingVolume = 5;
            finalGravityCalculator.FinalVolume = 4.5;
            finalGravityCalculator.OriginalGravity = 1.05;
            var finalGravity = (finalGravityCalculator as Calculator).Calculate();
            Assert.AreEqual(1.05556, Math.Round(finalGravity, 5));

        }
    }
}
