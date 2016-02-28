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
            ICalculateAlcohol calculator = calculatorFactory.GetCalculator("Real");
            calculator.StartingGravity = 1.05;
            calculator.EndingGravity = 1.01;
            var realAlcohol = (calculator as Calculator).Calculate();
            Assert.AreEqual(65.72584, realAlcohol);
        }
        [TestMethod]
        public void ABWCalculation_Passes()
        {
        }
    }
}
