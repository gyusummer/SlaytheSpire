using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeFitter : MonoBehaviour
{
	public RectTransform[] children;
    public RectTransform myRect;
    private void Start()
    {
        TryGetComponent(out myRect);
        // 자신도 컴포넌트도 대상이 되기 때문에 있다면 0에 들어간다.
        children = GetComponentsInChildren<RectTransform>(true); 
        // 자식의 자식들도 검색하지만 너비 우선 탐색인듯 하다.
        Debug.Log(children.Length);
    }
    private void Update()
    {
        for(int n = 1; n < children.Length; n++)
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
