using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace FinalGravityCalculation
{
    public interface ICalculateFinalGravityFactory
    {
        ICalculateFinalGravity GetCalculator(IFinalGravityStrategy CalculationType);
    }

    public class CalculateFinalGravityFactory : ICalculateFinalGravityFactory
    {
        public ICalculateFinalGravity GetCalculator(IFinalGravityStrategy CalculationType)
        {
            ICalculateFinalGravity finalGravityCalculator = new FinalGravityCalculation();
            finalGravityCalculator.FinalGravityStrategy = CalculationType;
            return finalGravityCalculator;
        }
    }

    public interface IFinalGravityStrategy {
        double CalculateFinalGravity(ICalculateFinalGravity finalGravityDetails);
    }

    public class FinalGravityStrategy : IFinalGravityStrategy
    {
        public double CalculateFinalGravity(ICalculateFinalGravity finalGravityDetails)
        {
            if (finalGravityDetails.FinalVolume <= 0)
                throw new ArgumentOutOfRangeException("FinalVolume", "Final Volume must be greater than zero");
            if (finalGravityDetails.StartingVolume <= 0)
                finalGravityDetails new ArgumentOutOfRangeException("StartingVolume", "Starting Volume must be greater than zero");
            var finalGravity = 1 + (finalGravityDetails.StartingVolume * (System.Math.Abs(1 - finalGravityDetails.OriginalGravity) * 1000) / finalGravityDetails.FinalVolume / 1000);
            return finalGravity;

        }
    }


    public interface ICalculateFinalGravity
    {
        double OriginalGravity { get; set; }
        double StartingVolume { get; set; }
        double FinalVolume { get; set; }
        double Calculate();

        IFinalGravityStrategy FinalGravityStrategy { get; set; }
    }
    public class FinalGravityCalculation : Calculator, ICalculateFinalGravity
    {
        public FinalGravityCalculation() : base(CalculatableTypes.OriginalGravity)
        {

        }
        public double FinalVolume
        {
            get; set;
        }

        public double OriginalGravity
        {
            get; set;
        }

        public double StartingVolume
        {
            get; set;
        }

        public override double Calculate()
        {
           return this.FinalGravityStrategy.CalculateFinalGravity(this);
        }

        public IFinalGravityStrategy FinalGravityStrategy { get; set; }
    }
}
