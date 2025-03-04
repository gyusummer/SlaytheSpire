using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : AbstractCard
{
    public override void Awake()
    {
        Init();
    }

    public override void Init()
    {
        type = CardTypes.Attack;
        name = "강타";
        cost = 2;
        color = CardColors.Red;
        illuPath = "Cards/red/attack/bash.png";
        targetType = TargetTypes.Single;
        mainValue = 8;
        subValue = 2;
        SetDescription();
    }

    public override void Play()
    {
        
    }

    public override void SetDescription()
    {
        description = $"피해를 {mainValue} 줍니다.\n취약을 {subValue} 부여합니다.";
    }
}
