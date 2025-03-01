using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMortals : MonoBehaviour
{
    protected int maxHp;
    protected int curHp;
    protected int block = 0;
    protected List<AbstractStatus> statusList;
    protected bool isDead = false;

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
