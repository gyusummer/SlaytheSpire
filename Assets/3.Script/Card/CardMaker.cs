using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMaker : Singleton<CardMaker>
{
    [SerializeField] GameObject CardPrefab;
    [SerializeField] CardDatabase RedCommon;

    public Card MakeACard(int cardID)
    {
        GameObject g = Instantiate(CardPrefab);
        Card c = g.AddComponent<Card>();
        c.Init(RedCommon.cardList[cardID]);
        g.AddComponent<CardUI>();

        return c;
    }
}
