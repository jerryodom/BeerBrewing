using System;
using System.Collections.Generic;
using System.Text;

namespace AlcoholCalculation
{
    interface ICalculateAlcohol
    {
        decimal StartingGravity { get; set; }
        decimal EndingGravity { get; set; }

        decimal CalculateABV();
    }
    public class CalculateAlcohol : ICalculateAlcohol
    {
        public decimal StartingGravity { get; set;  }
        public decimal EndingGravity { get; set; }

        public decimal CalculateABV()
        {
            return 0.0;
        }
    }

}
