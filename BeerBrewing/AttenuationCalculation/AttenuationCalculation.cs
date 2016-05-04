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
        ICalculateAttenuation GetCalculator(IAttenuationStrategy CalculationType);

    }

    public class CalculateAttenuationFactory : ICalculateAttenuationFactory
    {
        public ICalculateAttenuation GetCalculator(IAttenuationStrategy CalculationType)
        {
            ICalculateAttenuation attenuation = new AttenuationCalculation();
            attenuation.AttenuationCalculationStrategy = CalculationType;
            return attenuation;
        }
    }

    public interface IAttenuationStrategy
    {
        double CalculateAttenuation(ICalculateAttenuation attenuationDetails);
    }
    public class ApparentAttenuationStrategy : IAttenuationStrategy
    {
        public double CalculateAttenuation(ICalculateAttenuation attenuationDetails)
        {
            if (attenuationDetails.StartingGravity == 1)
                throw new ArgumentOutOfRangeException("StartingGravity", 1, "1 is not a valid value for StartingGravity");
            return 100 * ((attenuationDetails.StartingGravity - attenuationDetails.EndingGravity) / (attenuationDetails.StartingGravity - 1));
        }
    }
    public class RealAttenuationStrategy : IAttenuationStrategy
    {
        public double CalculateAttenuation(ICalculateAttenuation attenuationDetails)
        {
            if (attenuationDetails.StartingGravity == 1)
                throw new ArgumentOutOfRangeException("StartingGravity", 1, "1 is not a valid value for StartingGravity");
            return (double)0.1808 * attenuationDetails.StartingGravity + (double)0.8192 * (100 * ((attenuationDetails.StartingGravity - attenuationDetails.EndingGravity) / (attenuationDetails.StartingGravity - 1)));
        }
    }

    public interface ICalculateAttenuation
    {
        double StartingGravity { get; set; }
        double EndingGravity { get; set; }

        IAttenuationStrategy AttenuationCalculationStrategy { get; set; }

        double Calculate();


    }
    public class AttenuationCalculation : Calculator, ICalculateAttenuation
    {
        public AttenuationCalculation() : base(CalculatableTypes.Percentage)
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
            return this.AttenuationCalculationStrategy.CalculateAttenuation(this);
        }
        public IAttenuationStrategy AttenuationCalculationStrategy { get; set; }
    }
}
