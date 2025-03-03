using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    [SerializeField]
    private Image targetImage;
    [SerializeField]
    private float AlphaMin;
    [SerializeField]
    private float AlphaMax;
    [SerializeField,Header("Sec")]
    public float BlingPeriod;

    float alphaMin;
    float alphaMax;
    float blingSpeed;
    
    private void OnEnable()
    {
        InitAlphas();
        StartCoroutine(BlingBling());
    }
    void InitAlphas()
    {
        if (AlphaMin == 0f) AlphaMin = 20f;
        if (AlphaMax == 0f) AlphaMax = 150f;
        if (BlingPeriod == 0f) BlingPeriod = 4f;

        alphaMin = AlphaMin / AlphaMax;
        alphaMax = AlphaMax / 255f;
        blingSpeed = (alphaMax - alphaMin) * 2f / BlingPeriod;
    }
    IEnumerator BlingBling()
    {
        while(true)
        {
            Color color = targetImage.color;
            if(color.a < alphaMin)
            {
                while(color.a <= alphaMax)
                {
                    color.a += blingSpeed * Time.deltaTime;
                    targetImage.color = color;
                    yield return null;
                }
            }
            else
            {
                while (color.a >= alphaMin)
                {
                    color.a -= blingSpeed * Time.deltaTime;
                    targetImage.color = color;
                    yield return null;
                }
            }
        }
    }
}
