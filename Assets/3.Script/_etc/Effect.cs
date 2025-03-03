using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Effect
{
    #region trash
    //public TargetTypes targetType;
    //public int effectValue;
    //public Effects effectType;
    //public Statuses status;
    //public string description;
    //[HideInInspector]
    //public List<AbstractMortals> target = new List<AbstractMortals>();

    //public Effect()
    //{
    //    string targetStr = "";
    //    switch (targetType)
    //    {
    //        case TargetTypes.Self:
    //            targetStr = "자신에게";
    //            break;
    //        case TargetTypes.Single:
    //            targetStr = "적에게";
    //            break;
    //        case TargetTypes.AllEnemy:
    //            targetStr = "모든 적에게";
    //            break;
    //    }
    //    switch (effectType)
    //    {
    //        case Effects.Damage:
    //            description = $"피해를 {effectValue} 줍니다.";
    //            break;
    //        case Effects.Block:
    //            description = $"방어도를 {effectValue} 얻습니다.";
    //            break;
    //        case Effects.GiveStatus:
    //            description = $"{status}번 상태를 {effectValue} 만큼 부여합니다.";
    //            break;
    //    }
    //    description = $"{targetStr} {description}";
    //}
    //public void invoke()
    //{
    //    switch (effectType)
    //    {
    //        case Effects.Damage:
    //            DealDamage(target,effectValue);
    //            break;
    //        case Effects.Block:
    //            GiveBlock(target, effectValue);
    //            break;
    //        case Effects.GiveStatus:
    //            GiveStatus(target, effectValue, status);
    //            break;
    //    }
    //}
    #endregion
    public static void DealDamage(List<AbstractMortals> ts, int v)
    {
        foreach (AbstractMortals t in ts)
        {
            t.GetDamage(v);
        }
    }
    public static void GiveBlock(List<AbstractMortals> ts, int v)
    {
        foreach (AbstractMortals t in ts)
        {
            t.GetBlock(v);
        }
    }
    public static void GiveStatus(List<AbstractMortals> ts, int v, Statuses s)
    {
        foreach(AbstractMortals t in ts)
        {
            t.GetStatus(v,s);
        }
    }
    public static void GiveCard()
    {

    }
    public static void Heal()
    {

    }
    public static void RaiseMaxHp()
    {

    }
    public static void Draw()
    {

    }
    public static void Exhaust()
    {

    }
}
