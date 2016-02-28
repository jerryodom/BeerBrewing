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
            ICalculateAttenuation calculator = calculatorFactory.GetCalculator("Real");
            calculator.StartingGravity = 1.05;
            calculator.EndingGravity = 1.01;
            var realAttenuation = (calculator as Calculator).Calculate();
            Assert.AreEqual(65.72584, realAttenuation);

        }
        [TestMethod]
        public void ApparentAttenuationTestMethod_Passes()
        {
            ICalculateAttenuationFactory calculatorFactory = new CalculateAttenuationFactory();
            ICalculateAttenuation calculator = calculatorFactory.GetCalculator("Apparent");
            calculator.StartingGravity = 1.05;
            calculator.EndingGravity = 1.01;
            var apparentAttenuation = (calculator as Calculator).Calculate();
            Assert.AreEqual(80, apparentAttenuation);

        }
        [TestMethod]
        public void ApparentAttenuationTestMethod_Fails_BadArgument()
        {
            try
            {
                ICalculateAttenuationFactory calculatorFactory = new CalculateAttenuationFactory();
                ICalculateAttenuation calculator = calculatorFactory.GetCalculator(null);
                calculator.StartingGravity = 1.05;
                calculator.EndingGravity = 1.01;
                var apparentAttenuation = calculator.CalculateAttenuation();
            }
            catch(Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }

        }
    }
}
