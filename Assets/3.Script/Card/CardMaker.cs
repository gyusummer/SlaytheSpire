using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMaker : Singleton<CardMaker>
{
    [SerializeField] GameObject CardPrefab;
    [SerializeField] private CardDictionary cardDict;
    public CardDictionary CardDict => cardDict;

    public AbstractCard MakeACard()
    {
        int r = UnityEngine.Random.Range(0, cardDict.redCommonCards.Count);
        Type t = cardDict.redCommonCards[(RedCommonCard)r];
        GameObject g = Instantiate(CardPrefab);
        AbstractCard c = g.AddComponent(t) as AbstractCard;
        g.AddComponent<CardUI>();
        return c;
    }
}