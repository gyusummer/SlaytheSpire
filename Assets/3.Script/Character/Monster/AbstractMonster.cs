using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMonster : AbstractMortals
{
    public int attackValue;
    public virtual void Behave() 
    {
        if (IsDead) return;
        Attack();
    }
    protected void Attack()
    {
        Player.Instance.GetDamage(attackValue);
    }
}
