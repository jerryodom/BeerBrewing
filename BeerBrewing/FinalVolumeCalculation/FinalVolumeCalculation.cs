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
        ICalculateFinalVolume GetCalculator(IFinalVolumeStrategy CalculationType);
    }
    public class CalculateBoilOffFactory : ICalculateBoilOffFactory
    {
        public ICalculateFinalVolume GetCalculator(IFinalVolumeStrategy CalculationType)
        {
            ICalculateFinalVolume calculator = new FinalVolumeCalculation();
            calculator.FinalVolumeStrategy = CalculationType;
            return calculator;

        }
    }

    public interface IFinalVolumeStrategy
    {
        double CalculateFinalVolume(ICalculateFinalVolume finalVolumeDetails);
    }

    public class FinalVolumeStrategy : IFinalVolumeStrategy
    {
        public double CalculateFinalVolume(ICalculateFinalVolume finalVolumeDetails)
        {
            var valueForReturn = finalVolumeDetails.StartingVolumeInGallons - finalVolumeDetails.BoilOffInGallons - finalVolumeDetails.LossFromCoolingShrinkageInGallons;
            if (finalVolumeDetails.OtherValuesToSubtractFromStartingVolume != null && finalVolumeDetails.OtherValuesToSubtractFromStartingVolume.Count != 0)
            {
                foreach (var valueToSubtract in finalVolumeDetails.OtherValuesToSubtractFromStartingVolume)
                {
                    valueForReturn -= valueToSubtract;
                }
            }
            if (valueForReturn < 0)
            {
                throw new ArgumentOutOfRangeException("StartingVolumeInGallons", "Your starting volume is less than your combined boil off, loss from shrinkage and other values.  Can't have a negative final volume");
            }
            return valueForReturn;

        }
    }



    public class FinalVolumeCalculation : Calculator, ICalculateFinalVolume
    {
        public FinalVolumeCalculation() : base(CalculatableTypes.USGallons)
        {

        }
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
            return this.FinalVolumeStrategy.CalculateFinalVolume(this);
        }
        public IFinalVolumeStrategy FinalVolumeStrategy { get; set; }
    }

    public interface ICalculateFinalVolume
    {
        double StartingVolumeInGallons { get; set; }

        double BoilOffInGallons { get; set; }

        double LossFromCoolingShrinkageInGallons { get; set; }

        List<double> OtherValuesToSubtractFromStartingVolume { get; set; }
        double Calculate();
        public IFinalVolumeStrategy FinalVolumeStrategy { get; set; }
    }
}
