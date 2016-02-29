using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilOffCalculator
{
    public class BoilOffCalculation
    {
        public interface ICalculateBoilOffFactory
        {
            ICalculateBoilOff GetCalculator(string CalculationType);

        }

        public class CalculateBoilOffFactory : ICalculateBoilOffFactory
        {
            public ICalculateBoilOff GetCalculator(string CalculationType)
            {
                return new BoilOffByVolumeCalculation();
            }
        }

        public interface ICalculateBoilOff
        {
            double BoilTimeInMinutes { get; set; }
            double StartingVolumeInGallons { get; set; }
            double EvaporationRateInPercent { get; set; }

        }
        public class BoilOffByVolumeCalculation : Calculator, ICalculateBoilOff
        {
            public double BoilTimeInMinutes
            {
                get; set;
            }

            public double StartingVolumeInGallons
            {
                get; set;
            }

            public double EvaporationRateInPercent
            {
                get; set;
            }

            public override double Calculate()
            {
                 return (this.StartingVolumeInGallons * (this.EvaporationRateInPercent / 100)) * (this.BoilTimeInMinutes / 60);
            }
        }
    }
}
