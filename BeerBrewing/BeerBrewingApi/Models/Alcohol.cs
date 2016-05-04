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
        /// Pre-Fermentation Original Gravity
        /// </summary>
        [Required]
        public double StartingGravity { get; set; }
        [Required]
        public double EndingGravity { get; set; }
        public double AlcoholByVolume { get; set; }
        public double AlcoholByWeight { get; set; }
        public double TemperatureFahrenheit { get; set; }
    }
}
