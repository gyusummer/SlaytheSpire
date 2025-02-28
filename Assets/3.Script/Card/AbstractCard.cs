using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractCard : MonoBehaviour
{
    [HideInInspector] public CardData cardData;
    [HideInInspector] public new string name;
    [HideInInspector] public int baseCost;
    [HideInInspector] public int upgCost;
    [HideInInspector] public int curCost;
    [HideInInspector] public int baseEffValue;
    [HideInInspector] public int upgEffValue;
    [HideInInspector] public int curEffValue;
    [HideInInspector] public CardColors color;
    [HideInInspector] public TargetTypes targetType;
    [HideInInspector] public string description;

    public abstract void SetDescription();
    public abstract void PlayACard();
}
