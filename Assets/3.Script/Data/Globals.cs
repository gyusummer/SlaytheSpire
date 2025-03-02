using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static string commonAttackFrame = "CardUI/cardui3.png[ComAttFrame]";
    public static string commonSkillFrame = "CardUI/cardui2.png[ComSkiFrame]";
    public static string commonPowerFrame = "CardUI/cardui.png[ComPowFrame]";
    public static string redAttackBackPath = "CardUI/cardui.png[Red_Attack]";
    public static string redSkillBackPath = "CardUI/cardui3.png[Red_Skill]";
    public static string redPowerBackPath = "CardUI/cardui3.png[Red_Power]";
    public static Dictionary<CardTypes, string> framePath = new Dictionary<CardTypes, string>
    {
        {CardTypes.Attack, commonAttackFrame},
        {CardTypes.Skill, commonSkillFrame},
        {CardTypes.Power, commonPowerFrame},
    };
    public static void GetCardUIAddress(CardTypes ct, out string backPath, out string framePath)
    {
        backPath = "";
        framePath = "";
        switch (ct)
        {
            case CardTypes.Attack:
                backPath = redAttackBackPath;
                framePath = commonAttackFrame;
                break;
            case CardTypes.Skill:
                backPath = redSkillBackPath;
                framePath = commonSkillFrame;
                break;
            case CardTypes.Power:
                backPath = redPowerBackPath;
                framePath = commonPowerFrame;
                break;
        }
    }
}
