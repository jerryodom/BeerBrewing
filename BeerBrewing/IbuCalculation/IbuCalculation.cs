using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace IbuCalculation
{
    public interface ICalculateIbuFactory
    {
        ICalculateIbu GetCalculator();

    }

    public class CalculateIbuFactory : ICalculateIbuFactory
    {
        public ICalculateIbu GetCalculator()
        {
            return new IbuCalculation();
        }
    }


    public interface IIbuStrategy
    {
        double CalculateIbus(IbuCalculation ibuDetails);
    }

    public class CalculateTinsethIbuStrategy : IIbuStrategy
    {
        public double CalculateIbus(IbuCalculation ibuDetails)
        {
            if (ibuDetails.BatchVolumeInGallons> 0 && ibuDetails.AlphaAcids > 0 && ibuDetails.HopeQuantityInOunces > 0)
            {
                var milligramsLiterOfAA = (ibuDetails.AlphaAcids / 100 * ibuDetails.HopeQuantityInOunces * 7490) / ibuDetails.BatchVolumeInGallons;
                var bignessFactor = 1.65 * System.Math.Pow(0.000125, (ibuDetails.BatchOriginalGravity - 1));
                var boilTimeFactor = (1 - System.Math.Pow(2.71828, (-0.04 * ibuDetails.BoilTimeInMinutes)))/4.15;
                var utilization = ibuDetails.BatchOriginalGravity * boilTimeFactor;
                var ibus = utilization * milligramsLiterOfAA;
                return ibus;
            }
            else
            {
                throw new ArgumentOutOfRangeException("BatchVolumeInGallons", "Batch Volume, Alpha Acids And Hop Quantity Must All Be Greater Than Zero!");
            }
        }
    }
    public class CalculateRagerIbuStrategy : IIbuStrategy
    {
        public double CalculateIbus(IbuCalculation ibuDetails)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICalculateIbu 
    {
        double BatchVolumeInGallons { get; set; }

        double BoilVolumeInGallons { get; set; }

        double BatchOriginalGravity { get; set; }

        double AlphaAcids { get; set; }

        double BoilTimeInMinutes { get; set; }

        double HopeQuantityInOunces { get; set; }
        
        IIbuStrategy IbuCalculationType { get; set; }

        void SetIbuType(IIbuStrategy ibuStrategy);
    }
    public class IbuCalculation : Calculator, ICalculateIbu
    {
        public double AlphaAcids
        {
            get; set;
        }

        public double BatchOriginalGravity
        {
            get; set;
        }

        public double BatchVolumeInGallons
        {
            get; set;
        }

        public double BoilTimeInMinutes
        {
            get; set;
        }

        public double BoilVolumeInGallons
        {
            get; set;
        }

        public double HopeQuantityInOunces
        {
            get; set;
        }

        public IIbuStrategy IbuCalculationType
        {
            get; set;
        }

        public override double Calculate()
        {
            return this.IbuCalculationType.CalculateIbus(this);
        }


        public void SetIbuType(IIbuStrategy ibuStrategy)
        {
            this.IbuCalculationType = ibuStrategy;
        }
    }


}
