using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMortals : MonoBehaviour
{
    int maxHp;
    int curHp;
    List<AbstractState> states;
}
