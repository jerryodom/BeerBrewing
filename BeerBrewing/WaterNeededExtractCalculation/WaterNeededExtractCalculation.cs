using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace WaterNeededExtractCalculation
{
    public interface ICalculateWaterNeededExtractFactory
    {
        ICalculateWaterNeededExtract GetCalculator(string CalculationType);

    }

    public class CalculateWaterNeededExtractFactory : ICalculateWaterNeededExtractFactory
    {
        public ICalculateWaterNeededExtract GetCalculator(string CalculationType)
        {
            return new WaterNeededExtractCalculation();
        }
    }

    public interface ICalculateWaterNeededExtract
    {
        double MashWaterVolumeInQuarts { get; set; }
        
        int BoilTimeInMinutes { get; set; }

        double EvaporationRatePercent { get; set; }

        double TopUpWaterInGallons { get; set; }

        double DesiredFinalVolumeInGallons { get; set; }

        double LossToTrubInGallons { get; set; }

        double GetTotalWaterNeededInGallons();

        double GetBoiledOffVolumeInGallons();
        
        double GetBoilVolumeInGallons();

        double GetCoolingLossInGallons();
    }

    public class WaterNeededExtractCalculation : Calculator, ICalculateWaterNeededExtract
    {
        public WaterNeededExtractCalculation() : base(CalculatableTypes.USGallons) { }

        public double GetBoiledOffVolumeInGallons()
        {
            return 0;
        }

        public int BoilTimeInMinutes
        {
            get; set;
        }

        public double GetBoilVolumeInGallons()
        {
                double step1 = (this.DesiredFinalVolumeInGallons - this.TopUpWaterInGallons + this.LossToTrubInGallons) * (this.EvaporationRatePercent / 100) * (this.BoilTimeInMinutes / 60);
                double step2 = (step1 +this.GetCoolingLossInGallons()) + (((step1 + this.GetCoolingLossInGallons()) * (this.EvaporationRatePercent / 100) * this.BoilTimeInMinutes / 60));
                double boilVolume = this.DesiredFinalVolumeInGallons + step2 - this.TopUpWaterInGallons + this.LossToTrubInGallons;
                return boilVolume;
            
        }

        public double CoolingLossVolumeInGallons
        {
            get; set;
        }

        public double DesiredFinalVolumeInGallons
        {
            get; set;
        }

        public double EvaporationRatePercent
        {
            get; set;
        }


        public double MashWaterVolumeInQuarts
        {
            get; set;
        }
        
        public double TopUpWaterInGallons
        {
            get; set;
        }

        public double GetCoolingLossInGallons()
        {
                return this.DesiredFinalVolumeInGallons * .041666;   //this .041666 number is a boil off constant
            
        }

        public double LossToTrubInGallons
        {
            get; set;
        }

        public double GetTotalWaterNeededInGallons()
        {
                double ltt = this.LossToTrubInGallons;
                double tup = this.TopUpWaterInGallons;
                double dfv = this.DesiredFinalVolumeInGallons;
            double coolingLoss = this.GetCoolingLossInGallons();
                double X1 = (dfv - tup + ltt) * (this.EvaporationRatePercent / 100) * ((double)this.BoilTimeInMinutes /60);
                double X2 = (X1 + coolingLoss) + (((X1 + coolingLoss) * (this.EvaporationRatePercent / 100) * (double)this.BoilTimeInMinutes /60));
                double totalWaterNeeded = dfv + X2 + ltt;

            return Math.Round(totalWaterNeeded, 2);
            
        }


        public override double Calculate()
        {
            //returns total water needed
            return this.GetTotalWaterNeededInGallons();

        }


    }
}
