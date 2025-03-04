using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeFitter : MonoBehaviour
{
	public RectTransform[] children;
    public RectTransform myRect;
    private void Update()
    {
        for(int n = 0; n < children.Length; n++)
        {
            if (children[n].gameObject.activeSelf)
            {
                //Debug.Log(children[n]);
                //Debug.Log(children[n].sizeDelta);
                myRect.sizeDelta = children[n].sizeDelta;
                return;
            }
        }
    }
}
