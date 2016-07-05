using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrometerAdjustCalculation
{

        public interface ICalculateHydrometerAdjustFactory
        {
            ICalculateHydrometerAdjust GetCalculator(IHydrometerAdjustStrategy CalculationType);
        }
        public class CalculateHydrometerAdjustFactory : ICalculateHydrometerAdjustFactory
        {
            public ICalculateHydrometerAdjust GetCalculator(IHydrometerAdjustStrategy CalculationType)
            {
                ICalculateHydrometerAdjust calculator = new HydrometerAdjustCalculation();
                calculator.HydrometerAdjustStrategy = CalculationType;
                return calculator;

            }
        }

        public interface IHydrometerAdjustStrategy
        {
            double CalculateHydrometerAdjust(ICalculateHydrometerAdjust finalGravityDetails);
        }

        public class HydrometerAdjustStrategy : IHydrometerAdjustStrategy
        {
            public double CalculateHydrometerAdjust(ICalculateHydrometerAdjust finalGravityDetails)
            {
                double finalGravity = 0;
                var sgRatio = (double)1.00130346 - (double)0.000134722124 * finalGravityDetails.TemperatureInFahrenheit + ((double)0.00000204052596 * finalGravityDetails.TemperatureInFahrenheit * finalGravityDetails.TemperatureInFahrenheit) - (double)2.32820948E-09 * finalGravityDetails.TemperatureInFahrenheit * finalGravityDetails.TemperatureInFahrenheit * finalGravityDetails.TemperatureInFahrenheit;
                var ctRatio = (double)1.00130346 - (double)0.000134722124 * finalGravityDetails.CalibrationTemperatureInFahrenheit + ((double)0.00000204052596 * finalGravityDetails.CalibrationTemperatureInFahrenheit * finalGravityDetails.CalibrationTemperatureInFahrenheit) - (double)2.32820948E-09 * finalGravityDetails.CalibrationTemperatureInFahrenheit * finalGravityDetails.CalibrationTemperatureInFahrenheit * finalGravityDetails.CalibrationTemperatureInFahrenheit;

                if(ctRatio != 0)
                {
                    finalGravity = finalGravityDetails.MeasuredSpecificGravity * (sgRatio / ctRatio);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("CalibrationTemperatureInFahrenheit", "Calibration temperature must be a valid Fahrenheit number greater than zero.");
                }
                return finalGravity;

            }
        }



        public class HydrometerAdjustCalculation : Calculator, ICalculateHydrometerAdjust
        {
            public HydrometerAdjustCalculation() : base(CalculatableTypes.OriginalGravity)
            {

            }
            public double TemperatureInFahrenheit { get; set; }

            public double CalibrationTemperatureInFahrenheit { get; set; }

            public double MeasuredSpecificGravity { get; set; }

            public override double Calculate()
            {
                return this.HydrometerAdjustStrategy.CalculateHydrometerAdjust(this);
            }
            public IHydrometerAdjustStrategy HydrometerAdjustStrategy { get; set; }
        }

        public interface ICalculateHydrometerAdjust
        {
            double TemperatureInFahrenheit { get; set; }

            double CalibrationTemperatureInFahrenheit { get; set; }

            double MeasuredSpecificGravity { get; set; }
            
            double Calculate();
            IHydrometerAdjustStrategy HydrometerAdjustStrategy { get; set; }
        }
    }
