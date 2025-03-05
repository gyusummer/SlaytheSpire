using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMaker : Singleton<CardMaker>
{
    [SerializeField] GameObject CardPrefab;

    public Card MakeACard(int id = -1)
    {
        if(id == -1)
        {
            id = UnityEngine.Random.Range(0, CardDictionary.redCommonCards.Count);
        }
        Type t = CardDictionary.redCommonCards[(RedCommonCard)id];
        GameObject g = Instantiate(CardPrefab);
        Card c = g.AddComponent(t) as Card;
        g.AddComponent<CardUI>();
        return c;
    }
}