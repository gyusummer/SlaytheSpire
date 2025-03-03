using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ironclad : Player
{
    private void Start()
    {
        Init();
        //Debug.Log(money);
    }
    public void Init()
    {
        MaxHp = 80;
        CurHp = MaxHp;
        //for(int n = 0; n < 5; n++)
        //{
        //    AbstractCard c = CardMaker.Instance.MakeACard(0);
        //    deck.Add(c);
        //}
        //for(int n = 0; n < 4; n++)
        //{
        //    AbstractCard c = CardMaker.Instance.MakeACard(1);
        //    deck.Add(c);
        //}
        //deck.Add(CardMaker.Instance.MakeACard(2));
        for(int n = 0; n < 20; n++)
        {
            AddCardTo(CardMaker.Instance.MakeACard(),Deck,true);
        }
    }
}
