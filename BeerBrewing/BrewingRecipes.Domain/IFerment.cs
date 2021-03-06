﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewingRecipes.Domain
{
    /// <summary>
    /// IFerment - Anything which will cause fermentation.  Yeast, Bacteria primarily.
    /// </summary>
    public interface IFerment : IIngredient
    {
        double Attenuation { get; set; }
        FermenterPitchType PitchType { get; set; }

    }

    public enum FermenterPitchType
    {
        Dry,
        Liquid,
        StirPlate
    }

}
