using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilOffCalculaton
{
    public interface ICalculateBoilOffFactory
    {
        ICalculateBoilOff GetCalculator(IBoilOffStrategy boilOffStrategy);

    }

    public class CalculateBoilOffFactory : ICalculateBoilOffFactory
    {
        public ICalculateBoilOff GetCalculator(IBoilOffStrategy boilOffStrategy)
        {
            ICalculateBoilOff boilOff = new BoilOffByVolumeCalculation();
            boilOff.BoilOffStrategy = boilOffStrategy;
            return boilOff;
        }
    }

    public interface IBoilOffStrategy
    {
        double CalculateBoilOff(ICalculateBoilOff boiloffDetails);
    }

    public class BoilOffStrategy : IBoilOffStrategy
    {
        public double CalculateBoilOff(ICalculateBoilOff boiloffDetails)
        {
            return (boiloffDetails.StartingVolumeInGallons * (boiloffDetails.EvaporationRateInPercent / 100)) * (boiloffDetails.BoilTimeInMinutes / 60);
        }
    }



    public interface ICalculateBoilOff
    {
        double BoilTimeInMinutes { get; set; }
        double StartingVolumeInGallons { get; set; }
        double EvaporationRateInPercent { get; set; }

        double Calculate();

        IBoilOffStrategy BoilOffStrategy { get; set; }

    }
    public class BoilOffByVolumeCalculation : Calculator, ICalculateBoilOff
    {
        public BoilOffByVolumeCalculation() : base(CalculatableTypes.USGallons)
        {

        }
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

        public IBoilOffStrategy BoilOffStrategy
        {
            get; set;
        }

        public override double Calculate()
        {
            return this.BoilOffStrategy.CalculateBoilOff(this);
        }

    }
}
