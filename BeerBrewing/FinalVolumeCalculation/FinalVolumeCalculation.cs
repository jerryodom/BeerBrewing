using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace FinalVolumeCalculation
{
    public interface ICalculateBoilOffFactory
    {
        ICalculateFinalVolume GetCalculator(string CalculationType);
    }
    public class CalculateBoilOffFactory : ICalculateBoilOffFactory
    {
        public ICalculateFinalVolume GetCalculator(string CalculationType)
        {
            return new FinalVolumeCalculation();
        }
    }

    public class FinalVolumeCalculation : Calculator, ICalculateFinalVolume
    {
        public double BoilOffInGallons
        {
            get; set;
        }

        public double LossFromCoolingShrinkageInGallons
        {
            get; set;
        }

        public List<double> OtherValuesToSubtractFromStartingVolume
        {
            get; set;
        }

        public double StartingVolumeInGallons
        {
            get; set;
        }

        public override double Calculate()
        {
            var valueForReturn = StartingVolumeInGallons - BoilOffInGallons - LossFromCoolingShrinkageInGallons;
            if(OtherValuesToSubtractFromStartingVolume != null && OtherValuesToSubtractFromStartingVolume.Count != 0)
            {
                foreach(var valueToSubtract in OtherValuesToSubtractFromStartingVolume)
                {
                    valueForReturn -= valueToSubtract;
                }
            }
            if(valueForReturn < 0)
            {
                throw new ArgumentOutOfRangeException("StartingVolumeInGallons", "Your starting volume is less than your combined boil off, loss from shrinkage and other values.  Can't have a negative final volume");
            }
            return valueForReturn;
        }
    }

    public interface ICalculateFinalVolume
    {
        double StartingVolumeInGallons { get; set; }

        double BoilOffInGallons { get; set; }

        double LossFromCoolingShrinkageInGallons { get; set; }

        List<double> OtherValuesToSubtractFromStartingVolume { get; set; }
    }
}
