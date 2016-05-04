using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerBrewingApi.Models
{
    /// <summary>
    /// Calculate the amount of alcohol based on Original Gravity.(sugar content)
    /// </summary>
    public class AlcoholModel
    {
        /// <summary>
        /// Pre-Fermentation Original Gravity.  Usually in range of 1.00 to 1.20
        /// </summary>
        [Required]
        public double StartingGravity { get; set; }
        [Required]
        /// <summary>
        /// Post-Fermentation Gravity.  Usually in range of 1.00 to 1.20.  Always less than original gravity. 
        /// </summary>
        public double EndingGravity { get; set; }
        /// <summary>
        /// As a percentage.  ex. 5% 
        /// </summary>
        public double AlcoholByVolume { get; set; }
        /// <summary>
        /// As a percentage.  ex. 5% 
        /// </summary>
        public double AlcoholByWeight { get; set; }
        /// <summary>
        /// Degrees Fahrenheit.   
        /// </summary>
        public double TemperatureFahrenheit { get; set; }
    }
}
