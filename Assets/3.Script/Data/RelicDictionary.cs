using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RelicDictionary
{
    public static Dictionary<Relics, Type> relicDict = new Dictionary<Relics, Type>
    {
        {Relics.Burning_Blood, typeof(BurningBlood)},
    };
}
