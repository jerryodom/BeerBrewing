using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AttenuationCalculation;
using Core;

namespace AttenuationCalculationTests
{
    [TestClass]
    public class AttenuationCalculationTests
    {
        [TestMethod]
        public void RealAttenuationTestMethod_Passes()
        {
            ICalculateAttenuationFactory calculatorFactory = new CalculateAttenuationFactory();
            ICalculateAttenuation calculator = calculatorFactory.GetCalculator(new RealAttenuationStrategy());
            calculator.StartingGravity = 1.05;
            calculator.EndingGravity = 1.01;
            var realAttenuation = calculator.Calculate();
            Assert.AreEqual(65.72584, realAttenuation);

        }
        [TestMethod]
        public void ApparentAttenuationTestMethod_Passes()
        {
            ICalculateAttenuationFactory calculatorFactory = new CalculateAttenuationFactory();
            ICalculateAttenuation calculator = calculatorFactory.GetCalculator(new ApparentAttenuationStrategy());
            calculator.StartingGravity = 1.05;
            calculator.EndingGravity = 1.01;
            var apparentAttenuation = calculator.Calculate();
            Assert.AreEqual(80, apparentAttenuation);

        }

    }
}
