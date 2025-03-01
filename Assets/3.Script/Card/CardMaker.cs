using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMaker : MonoBehaviour
{
    public GameObject CardPrefab;
    public CardDatabase RedCommon;


    public Card MakeACard(int cardID)
    {
        Card card = new Card();
        card.Init(RedCommon.cardList[cardID]);

        return card;
    }
}
