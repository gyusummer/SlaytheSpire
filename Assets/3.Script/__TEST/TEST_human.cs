using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_human : MonoBehaviour
{
    public delegate int GetDamageHandler(int modifyValue);
    public event GetDamageHandler OnGetDamage;
    private void Awake()
    {
        Debug.Log("human Awake");
    }

    private void Start()
    {
        Debug.Log("human start");
        GetDamage(5);
    }

    public void GetDamage(int damage)
    {
        if(OnGetDamage != null)
        {
            foreach(System.Delegate d in OnGetDamage.GetInvocationList())
            {
                damage = (int)d.DynamicInvoke(damage);
            }
        }

        Debug.Log(damage);
    }
}