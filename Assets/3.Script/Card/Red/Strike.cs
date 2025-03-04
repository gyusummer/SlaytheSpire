using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Strike : AbstractCard
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
        subValue = -1;
        SetDescription();
    }

    public override void Play()
    {
        
    }

    public override void SetDescription()
    {
        description = $"피해를 {mainValue} 줍니다.";
    }
}
