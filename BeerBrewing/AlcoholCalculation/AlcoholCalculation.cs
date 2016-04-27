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
        ICalculateAlcohol GetCalculator(string CalculationType);

    }

    public class CalculateAlcoholFactory : ICalculateAlcoholFactory
    {
        public ICalculateAlcohol GetCalculator(string CalculationType)
        {
            if (CalculationType == "ABV")
            {
                return new AlcoholByVolumeCalculation();
            }
            else if (CalculationType == "ABW")
            {
                return new AlcoholByWeightCalculation();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Only ABV and ABW are valid Alcohol values.");
            }
        }
    }

    public interface ICalculateAlcohol
    {
        double StartingGravity { get; set; }
        double EndingGravity { get; set; }

    }
    public class AlcoholByVolumeCalculation : Calculator, ICalculateAlcohol
    {
        public AlcoholByVolumeCalculation() : base(CalculatableTypes.Percentage)
        {

        }
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
            if (this.EndingGravity == 0)
                throw new ArgumentOutOfRangeException("EndingGravity", 0, "0 is not a valid value for EndingGravity");
            return ((((double)1.05 * (this.StartingGravity - this.EndingGravity)) / this.EndingGravity) / (double)0.79) * 100;
        }
    }

    public class AlcoholByWeightCalculation : Calculator, ICalculateAlcohol
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
            if (this.EndingGravity == 0)
                throw new ArgumentOutOfRangeException("EndingGravity", 0, "0 is not a valid value for EndingGravity");
            return (((((double)1.05 * (this.StartingGravity - this.EndingGravity)) / this.EndingGravity) / (double)0.79) * 100) * (double)0.79336;
        }
    }
}
