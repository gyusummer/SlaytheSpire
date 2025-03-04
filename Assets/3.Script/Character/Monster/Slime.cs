using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : AbstractMonster
{

    private void Awake()
    {
        attackValue = 6;
        MaxHp = 25;
        CurHp = MaxHp;
    }
}
