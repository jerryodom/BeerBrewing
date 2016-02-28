using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlcoholCalculation;
using Core;

namespace AlcoholCalculationTests
{
    [TestClass]
    public class AlcoholCalculationTests
    {
        [TestMethod]
        public void ABVCalculation_Passes()
        {
            ICalculateAlcoholFactory calculatorFactory = new CalculateAlcoholFactory();
            ICalculateAlcohol calculator = calculatorFactory.GetCalculator("ABV");
            calculator.StartingGravity = 1.05;
            calculator.EndingGravity = 1.01;
            var abvAlcohol = (calculator as Calculator).Calculate();
            Assert.AreEqual(5.26381752099261, abvAlcohol);
        }
        [TestMethod]
        public void ABWCalculation_Passes()
        {
            {
                ICalculateAlcoholFactory calculatorFactory = new CalculateAlcoholFactory();
                ICalculateAlcohol calculator = calculatorFactory.GetCalculator("ABW");
                calculator.StartingGravity = 1.05;
                calculator.EndingGravity = 1.01;
                var abwAlcohol = (calculator as Calculator).Calculate();
                Assert.AreEqual(4.1761022684546969, abwAlcohol);
            }
        }
        [TestMethod]
        public void AlcoholCalculationTestMethod_Fails_BadArgument()
        {
            try
            {
                ICalculateAlcoholFactory calculatorFactory = new CalculateAlcoholFactory();
                ICalculateAlcohol calculator = calculatorFactory.GetCalculator("garbage");
                calculator.StartingGravity = 1.05;
                calculator.EndingGravity = 1.01;
                var alcoholCalculator = (calculator as Calculator).Calculate();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }

        }
    }
}
