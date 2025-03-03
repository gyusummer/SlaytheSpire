using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMortals : Singleton<AbstractMortals>
{
    public int maxHp { get; protected set; }
    public int curHp { get; protected set; }
    public int block { get; protected set; } = 0;
    public List<AbstractStatus> statusList { get; protected set; } = new List<AbstractStatus>();
    public bool isDead{ get; protected set; } = false;

    public void GetDamage(int damage)
    {
        block -= damage;
        if(block < 0)
        {
            curHp -= block;
            block = 0;
            if (curHp <= 0)
            {
                curHp = 0;
                isDead = true;
            }
        }
    }
    public void GetBlock(int value)
    {
        block += value;
    }
    public void GetStatus(int value, Statuses s)
    {
        statusList.Add(new AbstractStatus());// UNDONE
    }
}
