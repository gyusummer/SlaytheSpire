using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Strike : SingleTargetCard
{
    public override void Awake()
    {
        Init();
    }

    public override void Init()
    {
        type = CardTypes.Attack;
        name = "타격";
        cost = 1;
        color = CardColors.Red;
        illuPath = "Cards/red/attack/strike.png";
        targetType = TargetTypes.Single;
        mainValue = 6;
        IndicatedValue = mainValue;
        subValue = -1;
        SetDescription();
    }

    public override void Play(Mortal mob)
    {
        mob.GetDamage(IndicatedValue);
    }
    public override void SetDescription()
    {
        Description = $"피해를 {IndicatedValue} 줍니다.";
    }
}
