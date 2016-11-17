using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.Domain
{
    public class Style : IStyle
    {
        public string GuidelineVersion
        {
            get;set;
        }

        public string Name
        {
            get;set;
        }
    }

    public interface IStyle
    {
        string Name { get; set; }
        string GuidelineVersion { get; set; }

    }
}
