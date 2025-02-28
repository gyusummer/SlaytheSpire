using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : AbstractCard
{

    private void Awake()
    {
        name = "Ÿ��";
        baseCost = 1;
        upgCost = 1;
        baseEffValue = 6;
        upgEffValue = 9;
        color = CardColors.Red;
        targetType = TargetTypes.Single;

        curCost = baseCost;
        curEffValue = baseEffValue;
        SetDescription();
    }
    public override void SetDescription()
    {
        description = $"���ظ� {curEffValue} �ݴϴ�.";
    }

}
