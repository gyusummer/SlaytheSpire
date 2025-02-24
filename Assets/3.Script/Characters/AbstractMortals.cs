using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMortals : MonoBehaviour
{
    int hp;
    List<AbstractState> states;

    protected abstract void TakeDamage();
    protected abstract void TakeHeal();
}
