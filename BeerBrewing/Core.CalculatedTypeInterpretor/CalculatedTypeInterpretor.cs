using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
namespace Core.CalculatedTypeInterpretor
{
    public abstract class CalculatedTypeInterpretor
    {
        public abstract double Interpret(ICalculate<double> calculator);
    }

    public class OriginalGravityToBrixCalculatedTypeInterpretor : CalculatedTypeInterpretor
    {
        public override double Interpret(ICalculate<double> calculator)
        {
            if(calculator.CalculatedType == CalculatableTypes.OriginalGravity)
            {
                var originalValue = calculator.Calculate();
                return (((182.4601 * originalValue - 775.6821) * originalValue + 1262.7794) * originalValue - 669.5622);
            }
            else
            {
                throw new InvalidOperationException("Calculator must have CalculatedType of OriginalGravity to be valid!");
            }
        }
    }
    public class OriginalGravityToPlatoCalculatedTypeInterpretor : CalculatedTypeInterpretor
    {
        public override double Interpret(ICalculate<double> calculator)
        {
            if (calculator.CalculatedType == CalculatableTypes.OriginalGravity)
            {
                var originalValue = calculator.Calculate();
                return ((-1 * 616.868) + (1111.14 * originalValue) - (630.272 * (originalValue * originalValue)) + (135.997 * (originalValue* originalValue* originalValue)));
            }
            else
            {
                throw new InvalidOperationException("Calculator must have CalculatedType of OriginalGravity to be valid!");
            }
        }
    }
}
