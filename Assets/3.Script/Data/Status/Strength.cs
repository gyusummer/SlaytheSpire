using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : Status
{
    public Strength(Mortals mortals)
    {
        Debug.Log("��");
        description = "";
        imagePath = "Powers.png[Strength]";
        host = mortals;
    }

    public override void GetEffect()
    {
        host.OnAttack += IncreaseAttackDamgage;
    }

    public override void LoseEffect()
    {
        //throw new System.NotImplementedException();
    }

    int IncreaseAttackDamgage(int baseValue)
    {
        return baseValue + stack;
    }

}
