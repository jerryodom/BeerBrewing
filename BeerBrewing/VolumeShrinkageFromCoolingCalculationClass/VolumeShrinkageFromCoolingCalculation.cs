using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace VolumeShrinkageFromCoolingCalculation
{
    public interface ICalculateVolumeShrinkageFromCoolingFactory
    {
        ICalculateVolumeShrinkageFromCooling GetCalculator(IVolumeShrinkageFromCoolingStrategy CalculationType);

    }

    public class CalculateVolumeShrinkageFromCoolingFactory : ICalculateVolumeShrinkageFromCoolingFactory
    {
        public ICalculateVolumeShrinkageFromCooling GetCalculator(IVolumeShrinkageFromCoolingStrategy CalculationType)
        {
            ICalculateVolumeShrinkageFromCooling calculator = new VolumeShrinkageFromCoolingCalculation();
            calculator.VolumeShrinkageFromCoolingStrategy = CalculationType;
            return calculator;
        }
    }

    public class VolumeShrinkageFromCoolingStrategy : IVolumeShrinkageFromCoolingStrategy
    {
        public double CalculateVolumeShrinkageFromCooling(ICalculateVolumeShrinkageFromCooling volumeDetails)
        {
            return volumeDetails.VolumeAfterBoilOff * volumeDetails.CoolingLossInPercent / 100;
        }
    }
    public interface IVolumeShrinkageFromCoolingStrategy
    {
        double CalculateVolumeShrinkageFromCooling(ICalculateVolumeShrinkageFromCooling volumeDetails);
    }
    public class VolumeShrinkageFromCoolingCalculation : Calculator, ICalculateVolumeShrinkageFromCooling
    {
        public VolumeShrinkageFromCoolingCalculation() : base(CalculatableTypes.USGallons) { }

        public IVolumeShrinkageFromCoolingStrategy VolumeShrinkageFromCoolingStrategy
        {
            get; set;
        }

        public double CoolingLossInPercent
        {
            get; set;
        }

        public double StartingVolumeInGallons
        {
            get; set;
        }

        public double VolumeAfterBoilOff
        {
            get; set;
        }

        public override double Calculate()
        {
            return VolumeShrinkageFromCoolingStrategy.CalculateVolumeShrinkageFromCooling(this);
        }
    }




    public interface ICalculateVolumeShrinkageFromCooling
    {
        double VolumeAfterBoilOff { get; set; }
        double StartingVolumeInGallons { get; set; }
        double CoolingLossInPercent { get; set; }
        IVolumeShrinkageFromCoolingStrategy VolumeShrinkageFromCoolingStrategy { get; set; }

        double Calculate();

    }
}
