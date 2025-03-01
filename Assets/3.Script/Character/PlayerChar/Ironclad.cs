using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ironclad : AbstractPlayerCharacter
{
    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        maxHp = 80;
        curHp = maxHp;
        for(int n = 0; n < 5; n++)
        {
            Card c = CardMaker.Instance.MakeACard(0);
            deck.Add(c);
        }
        for(int n = 0; n < 4; n++)
        {
            Card c = CardMaker.Instance.MakeACard(1);
            deck.Add(c);
        }
        deck.Add(CardMaker.Instance.MakeACard(2));
    }
}
