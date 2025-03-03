using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_relic : MonoBehaviour
{
    public TEST_human hu;
    int modifyV = 1;
    private void Awake()
    {
        Debug.Log("relic Awake");
        hu.OnGetDamage += ModifyDamage4;
        hu.OnGetDamage += ModifyDamage3;
        hu.OnGetDamage += ModifyDamage2;
        hu.OnGetDamage += ModifyDamage;
    }
    private void Start()
    {
        Debug.Log("relic start");
    }
    public int ModifyDamage(int value)
    {
        value += modifyV;
        return value;
    }
    public int ModifyDamage2(int value)
    {
        value += modifyV * 2;
        return value;
    }
    public int ModifyDamage3(int value)
    {
        value += modifyV * 3;
        return value;
    }
    public int ModifyDamage4(int value)
    {
        value += modifyV * 4;
        return value;
    }
}
