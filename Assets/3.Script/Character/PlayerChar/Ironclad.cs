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
        for(int n = 0; n < 5; n++)
        {
            AddCardTo(CardMaker.Instance.MakeACard((int)RedCommonCard.Strike), Deck, true);
        }
        for (int n = 0; n < 4; n++)
        {
            AddCardTo(CardMaker.Instance.MakeACard((int)RedCommonCard.Defend), Deck, true);
        }
        for (int n = 0; n < 1; n++)
        {
            AddCardTo(CardMaker.Instance.MakeACard((int)RedCommonCard.Bash), Deck, true);
        }
        GetRelic(RelicMaker.Instance.MakeARelic(0));
    }
}
