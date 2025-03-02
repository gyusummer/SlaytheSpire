using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : AbstractCard
{
    public override void Awake()
    {
        Init();
    }

    public override void Init()
    {
        type = CardTypes.Skill;
        name = "수비";
        cost = 1;
        color = CardColors.Red;
        illuPath = "Cards/red/skill/defend.png";
        targetType = TargetTypes.Self;
        mainValue = 6;
        subValue = -1;
        SetDescription();
    }

    public override void PlayCard()
    {
        
    }

    public override void SetDescription()
    {
        description = $"방어도를 {mainValue} 얻습니다.";
    }
}
