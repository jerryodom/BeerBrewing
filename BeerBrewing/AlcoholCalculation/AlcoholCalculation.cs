using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoholCalculation
{
    public interface ICalculateAlcoholFactory
    {
        ICalculateAlcohol GetCalculator(IAlcoholStrategy calculationType);

    }

    public class CalculateAlcoholFactory : ICalculateAlcoholFactory
    {
        public ICalculateAlcohol GetCalculator(IAlcoholStrategy calculationType)
        {
            AlcoholCalculation calculator = new AlcoholCalculation();
            calculator.AlcoholCalculationStrategy = calculationType;
            return calculator;
        }
    }

    public interface IAlcoholStrategy
    {
        double CalculateAlcohol(ICalculateAlcohol alcoholDetails);
    }

    public class AlcoholByVolumeStrategy : IAlcoholStrategy
    {
        public double CalculateAlcohol(ICalculateAlcohol alcoholDetails)
        {
            if (alcoholDetails.EndingGravity == 0)
                throw new ArgumentOutOfRangeException("EndingGravity", 0, "0 is not a valid value for EndingGravity");
            return ((((double)1.05 * (alcoholDetails.StartingGravity - alcoholDetails.EndingGravity)) / alcoholDetails.EndingGravity) / (double)0.79) * 100;
        }
    }
    public class AlcoholByWeightStrategy : IAlcoholStrategy
    {
        public double CalculateAlcohol(ICalculateAlcohol alcoholDetails)
        {
            if (alcoholDetails.EndingGravity == 0)
                throw new ArgumentOutOfRangeException("EndingGravity", 0, "0 is not a valid value for EndingGravity");
            return (((((double)1.05 * (alcoholDetails.StartingGravity - alcoholDetails.EndingGravity)) / alcoholDetails.EndingGravity) / (double)0.79) * 100) * (double)0.79336;
        }
    }


    public interface ICalculateAlcohol
    {
        double StartingGravity { get; set; }
        double EndingGravity { get; set; }
        double Calculate();

    }
    public class AlcoholCalculation : Calculator, ICalculateAlcohol
    {
        public double EndingGravity
        {
            get; set;
        }

        public double StartingGravity
        {
            get; set;
        }

        public override double Calculate()
        {
            return this.AlcoholCalculationStrategy.CalculateAlcohol(this);
        }

        public IAlcoholStrategy AlcoholCalculationStrategy { get; set; }
    }
}
