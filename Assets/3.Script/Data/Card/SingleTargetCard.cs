using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleTargetCard : Card
{
    public abstract override void Play(Mortal mob);
    public override void PredictValue()
    {
        IndicatedValue = mainValue;
        if(Player.Instance.OnAttack != null)
        {
            foreach (Func<int, int> f in Player.Instance.OnAttack.GetInvocationList())
            {
                IndicatedValue = f(IndicatedValue);
            }
        }
        SetDescription();
    }
    public override void PredictValue(Monster target)
    {
        IndicatedValue = mainValue;
        if (Player.Instance.OnAttack != null)
        {
            foreach (Func<int, int> f in Player.Instance.OnAttack.GetInvocationList())
            {
                IndicatedValue = f(IndicatedValue);
            }
        }
        if (target.OnGetDamage != null)
        {
            foreach (Func<int, int> f in target.OnGetDamage.GetInvocationList())
            {
                IndicatedValue = f(IndicatedValue);
            }
        }
        SetDescription();
    }
}
