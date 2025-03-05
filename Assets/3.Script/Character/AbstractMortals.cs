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
            if (value <= 0)
            {
                curHp = 0;
            }
            else if (value >= maxHp)
            {
                curHp = maxHp;
            }
            else
            {
                curHp = value;
            }
            OnHpChanged?.Invoke();
        }
    }
    public int Block { get; protected set; } = 0;
    public List<AbstractStatus> StatusList { get; protected set; } = new List<AbstractStatus>();
    public bool IsDead{ get; protected set; } = false;
    protected virtual void Die()
    {
        IsDead = true;
        Destroy(gameObject);
    }
    public void GetDamage(int damage)
    {
        Block -= damage;
        if(Block < 0)
        {
            CurHp += Block;
            Block = 0;
            if (CurHp <= 0)
            {
                CurHp = 0;
                Die();
            }
        }
    }
    public void GetBlock(int value)
    {
        Block += value;
    }
    public void LoseBlock(int value)
    {
        Block -= value;
    }
    public void GetStatus(int value, Statuses s)
    {
        StatusList.Add(new AbstractStatus());
    }
    public void GetHeal(int value)
    {
        CurHp += value;
    }
}
