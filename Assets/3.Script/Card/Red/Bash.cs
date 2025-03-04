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
        name = "��Ÿ";
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
        description = $"���ظ� {mainValue} �ݴϴ�.\n����� {subValue} �ο��մϴ�.";
    }
}
