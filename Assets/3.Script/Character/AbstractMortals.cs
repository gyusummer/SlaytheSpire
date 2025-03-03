using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMortals : MonoBehaviour
{
    public event Action OnHpChanged;
    private int maxHp;
    public int MaxHp
    {
        get
        {
            return maxHp;
        }
        protected set
        {
            maxHp = value;
            OnHpChanged?.Invoke();
        }
    }
    private int curHp;
    public int CurHp
    {
        get
        {
            return curHp;
        }
        protected set
        {
            curHp = value;
            OnHpChanged?.Invoke();
        }
    }
    public int Block { get; protected set; } = 0;
    public List<AbstractStatus> StatusList { get; protected set; } = new List<AbstractStatus>();
    public bool IsDead{ get; protected set; } = false;

    
    public void GetDamage(int damage)
    {
        Block -= damage;
        if(Block < 0)
        {
            CurHp -= Block;
            Block = 0;
            if (CurHp <= 0)
            {
                CurHp = 0;
                IsDead = true;
            }
        }
    }
    public void GetBlock(int value)
    {
        Block += value;
    }
    public void GetStatus(int value, Statuses s)
    {
        StatusList.Add(new AbstractStatus());// UNDONE
    }
}
