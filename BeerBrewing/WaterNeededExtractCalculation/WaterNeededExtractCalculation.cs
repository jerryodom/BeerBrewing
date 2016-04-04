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

    }

    public class CalculateWaterNeededExtractFactory : ICalculateWaterNeededExtractFactory
    {
        public ICalculateWaterNeededExtract GetCalculator(string CalculationType)
        {
            return null;
        }
    }

    public interface ICalculateWaterNeededExtract
    {

    }

    public class WaterNeededExtractCalculation : Calculator, ICalculateWaterNeededExtract
    {
        public override double Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
