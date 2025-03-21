using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : Card
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

    public override void Play()
    {
        Player.Instance.GetBlock(mainValue);
    }

    public override void PredictValue()
    {

    }

    public override void SetDescription()
    {
        Description = $"방어도를 {mainValue} 얻습니다.";
    }
}
