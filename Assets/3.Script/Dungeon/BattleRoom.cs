using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoom : AbstractRoom
{
    public List<AbstractMonster> monsters;
    public BattleRoom(int x, int y) : base(x, y)
    {
        posX = x;
        posY = y;
        upRoom = new List<AbstractRoom>();
        downRoom = new List<AbstractRoom>();
    }
}
