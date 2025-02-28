using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    int seed;
    private void Start()
    {
        seed = Environment.TickCount;
        if(TryGetComponent(out AbstractCard abstractCard))
        {
            Debug.Log(abstractCard.GetType());
            Debug.Log(abstractCard.description);
        }
    }

    public void RandomNum()
    {
        Debug.Log($"{UnityEngine.Random.Range(2, 5)}");
    }
    public void ResetSeed()
    {
        UnityEngine.Random.seed = seed;
    }
}
