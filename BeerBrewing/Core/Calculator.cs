using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Calculator : ICalculate
    {
        public Calculator()
        {
        }
        public Calculator(CalculatableTypes calculatedType)
        {
            this._CalculatedType = calculatedType;
        }


        protected internal CalculatableTypes _CalculatedType;
        public CalculatableTypes CalculatedType
        {
            get
            {
                return this._CalculatedType;
            }
        }

        public virtual double Calculate()
        {
            return 0;
        }

        //    public abstract double Calculate();
    }

    public interface ICalculate
    {
        double Calculate();

        CalculatableTypes CalculatedType { get; }
    }

  
}

//public static class CalculatableTypes
//{
//    public static string USGallons = "USGallons";
//}
public enum CalculatableTypes
{
    USGallons,
    Quarts,
    Pints,
    Milliliters,
    PSI,
    Grams,
    Milligrams,
    Liters, 
    Ounces,
    OriginalGravity,
    Brix,
    Percentage, 
    IBU
}

