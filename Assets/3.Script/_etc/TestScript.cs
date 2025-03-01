using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject canvas;
    int seed;
    private void Start()
    {
        seed = Environment.TickCount;
        if(TryGetComponent(out Card abstractCard))
        {
            GameObject card = Instantiate(cardPrefab,canvas.transform);
            RawImage ri = card.GetComponentInChildren<RawImage>();
            ri.texture = abstractCard.illust.texture;
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
