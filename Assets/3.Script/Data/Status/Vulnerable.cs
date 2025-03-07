using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class Vulnerable : Status
{
    //public Vulnerable()
    //{
    //    Debug.Log("취약 0p");
    //    description = "";
    //    imagePath = "Powers.png[Vulnerable]";
    //}
    public Vulnerable(Mortals mortals)
    {
        //Debug.Log("취약 1p");
        description = "";
        imagePath = "Powers.png[Vulnerable]";
        host = mortals;
    }
    IEnumerator GetImage()
    {
        yield return Addressables.LoadAssetAsync<Image>(imagePath).Completed += (op) => image = op.Result;
    }
    public override void GetEffect()
    {
        host.OnGetDamage += GetMoreDamage;
    }
    public override void LoseEffect()
    {
        host.OnGetDamage -= GetMoreDamage;
    }
    int GetMoreDamage(int baseValue)
    {
        return (int)(baseValue * 1.5f);
    }
}
