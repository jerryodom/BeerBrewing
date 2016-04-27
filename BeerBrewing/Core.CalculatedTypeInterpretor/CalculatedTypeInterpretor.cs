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
        public abstract double Interpret(Calculator calculator);
    }

    public class OriginalGravityToBrixCalculatedTypeInterpretor : CalculatedTypeInterpretor
    {
        public override double Interpret(Calculator calculator)
        {
            if(calculator.CalculatedType == CalculatableTypes.OriginalGravity)
            {
                return 0;
            }
            else
            {
                throw new InvalidOperationException("Calculator must have CalculatedType of OriginalGravity to be valid!");
            }
        }
    }
}
