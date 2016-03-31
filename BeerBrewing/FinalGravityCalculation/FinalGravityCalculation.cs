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
        ICalculateFinalGravity GetCalculator(string CalculationType);
    }

    public class CalculateFinalGravityFactory : ICalculateFinalGravityFactory
    {
        public ICalculateFinalGravity GetCalculator(string CalculationType)
        {
            return new FinalGravityCalculation();
        }
    }

    public interface ICalculateFinalGravity
    {
        double OriginalGravity { get; set; }
        double StartingVolume { get; set; }
        double FinalVolume { get; set; }
    }
    public class FinalGravityCalculation : Calculator, ICalculateFinalGravity
    {
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
            if (this.FinalVolume <= 0)
                throw new ArgumentOutOfRangeException("FinalVolume", "Final Volume must be greater than zero");
            if(this.StartingVolume <= 0)
                throw new ArgumentOutOfRangeException("StartingVolume", "Starting Volume must be greater than zero");
            var finalGravity = 1 + (this.StartingVolume * (System.Math.Abs(1 - this.OriginalGravity) * 1000) / this.FinalVolume / 1000);
            return finalGravity;
        }
    }
}
