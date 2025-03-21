using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour
{
    public GameObject TargetGraphic;
    public float howBigger;
    public float howRot;
    //int tiltDir = 1;
    Vector2 orgSize;

    private void OnEnable()
    {
        if (howBigger == 0) howBigger = 1.2f;
        if (howRot == 0) howRot = 30f;
        if (TargetGraphic == null) TargetGraphic = gameObject;
        orgSize = TargetGraphic.transform.localScale;
    }
    public void GrowIconSize()
    {
        orgSize = TargetGraphic.transform.localScale;
        TargetGraphic.transform.localScale *= howBigger;
    }
    public void RestoreIconSize()
    {
        TargetGraphic.transform.localScale = orgSize;
    }
    public void RotateIcon()
    {
        TargetGraphic.transform.rotation = Quaternion.Euler(0, 0, howRot);
    }
    public void ResetRotation()
    {
        TargetGraphic.transform.rotation = Quaternion.identity;
    }
    //public void Tilt()
    //{
    //    // 0도에서 -howRot ~ +howRot 왔다갔다
    //    Quaternion rot = TargetGraphic.transform.rotation;
    //    Quaternion.Euler(0, 0, 1f * tiltDir);
    //    rot.z = rot.z + Quaternion.Euler(0, 0, 1f * tiltDir).z;
    //    TargetGraphic.transform.rotation = rot;
    //    Debug.Log(rot.z);
    //}
}
