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
        // �ڽŵ� ������Ʈ�� ����� �Ǳ� ������ �ִٸ� 0�� ����.
        children = GetComponentsInChildren<RectTransform>(true); 
        // �ڽ��� �ڽĵ鵵 �˻������� �ʺ� �켱 Ž���ε� �ϴ�.
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
