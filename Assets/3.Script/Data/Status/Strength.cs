using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : Status
{
    public Strength(Mortals mortals)
    {
        Debug.Log("Èû");
        description = "";
        imagePath = "Powers.png[Strength]";
        host = mortals;
    }

    public override void GetEffect()
    {
        host.OnAttack += IncreaseAttackDamgage;
    }

    int IncreaseAttackDamgage(int baseValue)
    {
        return baseValue + stack;
    }

}
