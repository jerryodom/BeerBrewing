using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace CarbonationCalculation
{


    public class CalculateCarbonationFactory : ICalculateCarbonationFactory
    {
        public ICalculateCarbonation GetCalculator(string CalculationType)
        {
            return new CarbonationCalculation();
        }
    }
    public interface ICalculateCarbonationFactory
    {
        ICalculateCarbonation GetCalculator(string CalculationType);
    }


    public interface ICarbonationStrategy
    {
        double CalculateCarbonation(CarbonationCalculation carbonationDetails);
    }

    public class CarbonateUsingDmeStrategy : ICarbonationStrategy
    {
        public double CalculateCarbonation(CarbonationCalculation carbonationDetails)
        {
            return ((double)21.27 * carbonationDetails.BeerVolumeInGallons) * (carbonationDetails.DesiredCarbonationInVolumes - (double)3.0378 + (double).050062 * carbonationDetails.BeerTemperatureInFahrenheit - (double).00026555 * carbonationDetails.BeerTemperatureInFahrenheit * carbonationDetails.BeerTemperatureInFahrenheit);

            //var sugaringrams = ((double)21.27 * bv) * (_cO2Volumes - (double)3.0378 + (double).050062 * bt - (double).00026555 * bt * bt);
        }
    }


    public class CarbonateUsingForcedPressureStrategy : ICarbonationStrategy
    {
        public double CalculateCarbonation(CarbonationCalculation carbonationDetails)
        {
            return (double)-16.6999 - ((double)0.0101059 * carbonationDetails.BeerTemperatureInFahrenheit) + ((double)0.00116512 * carbonationDetails.BeerTemperatureInFahrenheit * carbonationDetails.BeerTemperatureInFahrenheit) + ((double)0.173354 * carbonationDetails.BeerTemperatureInFahrenheit * carbonationDetails.DesiredCarbonationInVolumes) + ((double)4.24267 * carbonationDetails.DesiredCarbonationInVolumes) - ((double)0.0684226 * carbonationDetails.DesiredCarbonationInVolumes * carbonationDetails.DesiredCarbonationInVolumes);
        }
    }


    public interface ICalculateCarbonation
    {
        double BeerVolumeInGallons { get; set; }
        double BeerTemperatureInFahrenheit { get; set; }

        double DesiredCarbonationInVolumes { get; set; }
        
        void SetCarbonationType(ICarbonationStrategy carbonationStrategy);
    }

    public class CarbonationCalculation : Calculator, ICalculateCarbonation
    {
        public double BeerTemperatureInFahrenheit
        {
            get; set;
        }

        public double BeerVolumeInGallons
        {
            get; set;
        }

        public double DesiredCarbonationInVolumes
        {
            get; set;
        }

        public void SetCarbonationType(ICarbonationStrategy strategy)
        {
            this.CarbonationType = strategy;
        }

        ICarbonationStrategy CarbonationType
        {
            get; set;
        }
        

        public override double Calculate()
        {
            return this.CarbonationType.CalculateCarbonation(this);
        }
    }
}
