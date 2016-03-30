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
        ICalculateVolumeShrinkageFromCooling GetCalculator(string CalculationType);

    }

    public class CalculateVolumeShrinkageFromCoolingFactory : ICalculateVolumeShrinkageFromCoolingFactory
    {
        public ICalculateVolumeShrinkageFromCooling GetCalculator(string CalculationType)
        {
            return new VolumeShrinkageFromCoolingCalculation();
        }
    }
    public class VolumeShrinkageFromCoolingCalculation : Calculator, ICalculateVolumeShrinkageFromCooling
    {
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
            return VolumeAfterBoilOff * CoolingLossInPercent / 100;
        }
    }




    public interface ICalculateVolumeShrinkageFromCooling
    {
        double VolumeAfterBoilOff { get; set; }
        double StartingVolumeInGallons { get; set; }
        double CoolingLossInPercent { get; set; }

    }
}
