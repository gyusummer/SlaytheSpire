using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : AbstractMonster
{
    private void Awake()
    {
        attackValue = 15;
        MaxHp = 66;
        CurHp = MaxHp;
    }
}
