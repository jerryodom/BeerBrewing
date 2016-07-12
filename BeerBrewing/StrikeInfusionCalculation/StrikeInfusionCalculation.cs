using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeInfusionCalculation
{
    public interface ICalculateStrikeInfusionFactory
    {
        ICalculateStrikeInfusion GetCalculator(IStrikeInfusionStrategy strikeInfusionStrategy);

    }

    public class CalculateStrikeInfusionFactory : ICalculateStrikeInfusionFactory
    {
        public ICalculateStrikeInfusion GetCalculator(IStrikeInfusionStrategy strikeInfusionStrategy)
        {
            ICalculateStrikeInfusion myCalculator = new StrikeInfusionCalculation();
            myCalculator.StrikeInfusionCalculationType = strikeInfusionStrategy;
            return myCalculator;
        }
    }


    public interface IStrikeInfusionStrategy
    {
        double CalculateStrikeInfusion(StrikeInfusionCalculation strikeInfusionDetails);
    }

    public class CalculateStrikeInfusionStrikeTemperaturFahrenheiteOfWaterToAddStrategy : IStrikeInfusionStrategy
    {
        public double CalculateStrikeInfusion(StrikeInfusionCalculation strikeInfusionDetails)
        {
            var targetTemp = (((strikeInfusionDetails.TargetStepTemperature - strikeInfusionDetails.InitialMashTemperatureFahrenheit) * ((double)0.2 * strikeInfusionDetails.WeightOfGrainInPounds + strikeInfusionDetails.StartingWaterVolumeInQuarts)) + strikeInfusionDetails.WaterToAddInQuarts * strikeInfusionDetails.TargetStepTemperature) / strikeInfusionDetails.WaterToAddInQuarts;
            return targetTemp;
        }
    }
    public class CalculateStrikeInfusionInitialStepStrikeTemperaturFahrenheiteOfWaterToAddStrategy : IStrikeInfusionStrategy
    {
        public double CalculateStrikeInfusion(StrikeInfusionCalculation strikeInfusionDetails)
        {
            throw new Exception("Not yet implmenented.  Looking for new formula.");
            if (strikeInfusionDetails.WeightOfGrainInPounds <= 0)
            {
                throw new ArgumentOutOfRangeException("WeightOfGrainInPounds", "Weight of grain must be greater than zero.");
            }
            if (strikeInfusionDetails.WaterToAddInQuarts <= 0)
            {
                throw new ArgumentOutOfRangeException("WaterToAddInQuarts", "Water to add must be greater than zero.");
            }
            double waterToAdd = strikeInfusionDetails.WaterToAddInQuarts / strikeInfusionDetails.WeightOfGrainInPounds;
            double strikeTempFahrenheit = (((double).2 / (strikeInfusionDetails.WaterToAddInQuarts / strikeInfusionDetails.WeightOfGrainInPounds)) * (strikeInfusionDetails.TargetStepTemperature - strikeInfusionDetails.InitialMashTemperatureFahrenheit)) + strikeInfusionDetails.TargetStepTemperature;
            //1.918 is the Thermal mass of a converted keg.  ThM = ((Ts-Td)*2.08635*Vw)/(Td-Tm)
            //strikeTempFahrenheit = (((strikeInfusionDetails.TargetStepTemperature * (.3 + (2.08635 * strikeInfusionDetails.WaterToAddInQuarts) + (0.4 * strikeInfusionDetails.WeightOfGrainInPounds))) - (strikeInfusionDetails.InitialMashTemperatureFahrenheit * 0.4 * strikeInfusionDetails.WeightOfGrainInPounds)) - (strikeInfusionDetails.InitialMashTemperatureFahrenheit * .3)) / (2.08635 * strikeInfusionDetails.WeightOfGrainInPounds);


            return strikeTempFahrenheit;
        }
    }
    public interface ICalculateStrikeInfusion
    {
        double StartingWaterVolumeInQuarts
        {
            get; set;
        }

        double WaterToAddInQuarts
        {
            get; set;
        }

        double TargetStepTemperature
        {
            get; set;
        }
        double MashTunInfusionAdjustmentDegreesPerPound
        {
            get; set;
        }

        double WeightOfGrainInPounds
        {
            get; set;
        }

        double InitialMashTemperatureFahrenheit
        {
            get; set;
        }

        double MashTunWeightInPounds
        {
            get; set;
        }
        
        IStrikeInfusionStrategy StrikeInfusionCalculationType { get; set; }

        void SetStrikeInfusionType(IStrikeInfusionStrategy strikeInfusionStrategy);
        double Calculate();
    }

    public class StrikeInfusionCalculation : Calculator, ICalculateStrikeInfusion
    {
        public StrikeInfusionCalculation() : base(CalculatableTypes.Quarts)
        {

        }
        public double StartingWaterVolumeInQuarts
        {
            get; set;
        }

        public double WaterToAddInQuarts
        {
            get; set;
        }

        public double TargetStepTemperature
        {
            get; set;
        }
        public double MashTunInfusionAdjustmentDegreesPerPound
        {
            get; set;
        }

        public double WeightOfGrainInPounds
        {
            get; set;
        }

        public double InitialMashTemperatureFahrenheit
        {
            get; set;
        }

        public double MashTunWeightInPounds
        {
            get; set;
        }

        public bool IsInfusionStep
        {
            get; set;
        }
        public bool IsInitialStrike
        {
            get; set;
        }

        public IStrikeInfusionStrategy StrikeInfusionCalculationType
        {
            get; set;
        }

        public override double Calculate()
        {
            return this.StrikeInfusionCalculationType.CalculateStrikeInfusion(this);
        }


        public void SetStrikeInfusionType(IStrikeInfusionStrategy StrikeInfusionStrategy)
        {
            this.StrikeInfusionCalculationType = StrikeInfusionStrategy;
        }
    }
}
