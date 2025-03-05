using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

public abstract class Relic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string imagePath;
    public RelicRarities rarity;
    public new string name;
    public string description;
    public GameObject dscObj;
    protected void Awake()
    {
        SetImage();
        dscObj = transform.GetChild(0).gameObject;
        Text[] texts = dscObj.GetComponentsInChildren<Text>();
        texts[0].text = name;
        texts[1].text = description;
    }
    public abstract void GetEffect();
    void SetImage()
    {
        if(TryGetComponent(out Image image))
        {
            Addressables.LoadAssetAsync<Sprite>(imagePath).Completed += (op) => image.sprite = op.Result;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dscObj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dscObj.SetActive(false);
    }
}