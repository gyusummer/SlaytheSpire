using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class Card : MonoBehaviour
{
    public CardData cardData;
    [HideInInspector] public new string name;
    [HideInInspector] public CardTypes type;
    [HideInInspector] public int curCost;
    [HideInInspector] public CardColors color;
    [HideInInspector] public string description;
    [HideInInspector] public Sprite illust;
    [HideInInspector] public List<Effect> effects;
    public void Init(CardData d)
    {
        cardData = d;
        name = cardData.Name;
        type = cardData.CardType;
        curCost = cardData.BaseCost;

        color = cardData.Color;
        illust = cardData.Illust;
        effects = cardData.Effects;
        SetDescription();
    }
    public void SetDescription()
    {
        foreach(Effect e in effects)
        {
            description = $"{description}\n{e.description}";
        }
    }
    public void PlayACard()
    {

    }
}
