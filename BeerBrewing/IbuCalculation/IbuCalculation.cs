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
        ICalculateIbu GetCalculator(string CalculationType);

    }

    public class CalculateIbuFactory : ICalculateIbuFactory
    {
        public ICalculateIbu GetCalculator(string CalculationType)
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
                double val = ibuDetails.GetUtilization() * (ibuDetails.HopeQuantityInOunces * (ibuDetails.HopeQuantityInOunces / 100) * 7490) / ibuDetails.BatchVolumeInGallons;
                return val;
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

        double GetUtilization();

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

        public double GetUtilization()
        {
            double val = 0;
            if (this.BatchOriginalGravity > 0)
            {
                double part1 = System.Math.Pow(0.000125, (this.BatchOriginalGravity - 1));
                double part2 = System.Math.Pow(2.72, (-0.04 * this.BoilTimeInMinutes));
                val = (1.65 * part1) * (1 - part2) / 4.14;

            }
            else
            {
                throw new ArgumentOutOfRangeException("BatchOriginalGravity", "Batch Original Gravity Must Be Greater Than Zero");
            }
            return val;
        }

        public void SetIbuType(IIbuStrategy ibuStrategy)
        {
            throw new NotImplementedException();
        }
    }


}
