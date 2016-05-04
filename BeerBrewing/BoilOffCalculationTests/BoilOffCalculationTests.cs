using Core;
using BoilOffCalculaton;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BoilOffCalculationTests
{
    [TestClass]
    public class BoilOffCalculationTests
    {
        [TestMethod]
        public void CalculateBoilOff_Passes()
        {
            ICalculateBoilOffFactory calculatorFactory = new CalculateBoilOffFactory();
            ICalculateBoilOff calculator = calculatorFactory.GetCalculator(new BoilOffStrategy());
            calculator.BoilTimeInMinutes = 60;
            calculator.StartingVolumeInGallons = 5;
            calculator.EvaporationRateInPercent = 4;
            var boiledOffVolumeInGalls = calculator.Calculate();
            Assert.AreEqual(0.2, boiledOffVolumeInGalls);
        }
    }
}
