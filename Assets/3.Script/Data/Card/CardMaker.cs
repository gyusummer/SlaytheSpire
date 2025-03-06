using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMaker : Singleton<CardMaker>
{
    [SerializeField] GameObject CardPrefab;

    public Card MakeACard(RedCommonCard id = RedCommonCard.Random)
    {
        if(id == RedCommonCard.Random)
        {
            id = (RedCommonCard)UnityEngine.Random.Range(0, CardDictionary.redCommonCards.Count);
        }
        Type t = CardDictionary.redCommonCards[id];
        GameObject g = Instantiate(CardPrefab);
        Card c = g.AddComponent(t) as Card;
        g.AddComponent<CardUI>();
        return c;
    }
}