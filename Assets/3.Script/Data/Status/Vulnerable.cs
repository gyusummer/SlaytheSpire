using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Vulnerable : Status
{
    //public Vulnerable()
    //{
    //    Debug.Log("취약 0p");
    //    description = "";
    //    imagePath = "Powers.png[Vulnerable]";
    //}
    public Vulnerable(Mortal mortals)
    {
        //Debug.Log("취약 1p");
        description = "";
        imagePath = "Powers.png[Vulnerable]";
        host = mortals;
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(imagePath);
        image = handle.WaitForCompletion();
        Addressables.Release(handle);
        host.OnTurnEnd += LoseStack;
    }
    public override void GetEffect()
    {
        host.OnGetDamage += GetMoreDamage;
    }
    public override void LoseEffect()
    {
        host.OnGetDamage -= GetMoreDamage;
        host.OnTurnEnd -= LoseStack;
    }
    public void LoseStack()
    {
        host.LoseStatus(1,this);
    }
    int GetMoreDamage(int baseValue)
    {
        return (int)(baseValue * 1.5f);
    }
}
