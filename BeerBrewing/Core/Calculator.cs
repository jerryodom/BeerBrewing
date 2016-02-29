using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Calculator : ICalculate
    {
        public abstract double Calculate();
    }

    public interface ICalculate
    {
        double Calculate();
    }


}
