using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace AttenuationCalculation
{
    public interface ICalculateAttenuationFactory
    {
        ICalculateAttenuation GetCalculator(string CalculationType);

    }

    public class CalculateAttenuationFactory : ICalculateAttenuationFactory
    {
        public ICalculateAttenuation GetCalculator(string CalculationType)
        {
            if(CalculationType == "Real")
            {
                return new RealAttenuationCalculation();
            }
            else if(CalculationType == "Apparent")
            {
                return new ApparentAttenuationCalculation();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Only Real or Apparent are valid attenuation values.");
            }
        }
    }

    public interface ICalculateAttenuation
    {
        double StartingGravity { get; set; }
        double EndingGravity { get; set; }
        
    }
    public class ApparentAttenuationCalculation : Calculator, ICalculateAttenuation
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
            if (this.StartingGravity == 1)
                throw new ArgumentOutOfRangeException("StartingGravity", 1, "1 is not a valid value for StartingGravity");
             return 100 * ((this.StartingGravity - this.EndingGravity) / (this.StartingGravity - 1));
        }
    }

    public class RealAttenuationCalculation : Calculator,  ICalculateAttenuation
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
            if (this.StartingGravity == 1)
                throw new ArgumentOutOfRangeException("StartingGravity", 1, "1 is not a valid value for StartingGravity");
            return (double)0.1808 * this.StartingGravity + (double)0.8192 * (100 * ((this.StartingGravity - this.EndingGravity) / (this.StartingGravity - 1)));

        }
    }
}
