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
    //            targetStr = "�ڽſ���";
    //            break;
    //        case TargetTypes.Single:
    //            targetStr = "������";
    //            break;
    //        case TargetTypes.AllEnemy:
    //            targetStr = "��� ������";
    //            break;
    //    }
    //    switch (effectType)
    //    {
    //        case Effects.Damage:
    //            description = $"���ظ� {effectValue} �ݴϴ�.";
    //            break;
    //        case Effects.Block:
    //            description = $"���� {effectValue} ����ϴ�.";
    //            break;
    //        case Effects.GiveStatus:
    //            description = $"{status}�� ���¸� {effectValue} ��ŭ �ο��մϴ�.";
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
