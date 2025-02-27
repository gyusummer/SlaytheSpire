using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public GameObject TargetGraphic;
    public float howBigger;
    public float howRot;
    int tiltDir = 1;
    Vector2 initSize;

    private void OnEnable()
    {
        if (howBigger == 0) howBigger = 1.2f;
        if (howRot == 0) howRot = 30f;
        if (TargetGraphic == null) TargetGraphic = gameObject;
        Debug.Log(TargetGraphic);
        initSize = TargetGraphic.transform.localScale;
    }
    public void GrowIconSize()
    {
        TargetGraphic.transform.localScale *= howBigger;
    }
    public void ResetIconSize()
    {
        TargetGraphic.transform.localScale = initSize;
    }
    public void RotateIcon()
    {
        TargetGraphic.transform.rotation = Quaternion.Euler(0, 0, howRot);
    }
    public void ResetRotation()
    {
        TargetGraphic.transform.rotation = Quaternion.identity;
    }
    public void Tilt()
    {
        // 0도에서 -howRot ~ +howRot 왔다갔다
        Quaternion rot = TargetGraphic.transform.rotation;
        rot.z = rot.z + 1f * tiltDir;
        TargetGraphic.transform.rotation = rot;
        if (rot.z > howRot || rot.z < howRot) tiltDir *= -1;
        Debug.Log(tiltDir);
    }
}
