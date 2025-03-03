using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    AbstractCard card;
    //DungeonUIManager ui;
    Image[] cardImages;
    Image backImg;
    Image frameImg;
    RawImage cardIllust;
    Text[] textBoxes;
    Text descriptT;
    Text typeT;
    Text nameT;
    Text costT;
    private void Awake()
    {
        //ui = FindAnyObjectByType<DungeonUIManager>();
        //transform.SetParent(ui.transform, false);
        if (TryGetComponent(out card))
        {
            ChangeImages();
            ChangeTexts();
        }
        //gameObject.SetActive(false);
        //Debug.Log("카드UI 생성됨");
        transform.localScale = Vector2.one * 0.45f;
    }
    public void SetParent(Transform newParent)
    {
        //Debug.Log("카드UI의 SetParent");
        transform.SetParent(newParent);
    }
    void ChangeTexts()
    {
        textBoxes = GetComponentsInChildren<Text>();
        descriptT = textBoxes[0];
        typeT = textBoxes[1];
        nameT = textBoxes[2];
        costT = textBoxes[3];
        descriptT.text = card.description;
        typeT.text = Enum.GetName(typeof(CardTypes), card.type);
        nameT.text = card.name;
        costT.text = card.cost.ToString();
    }
    void ChangeImages()
    {
        cardImages = GetComponentsInChildren<Image>();
        backImg = cardImages[0];
        frameImg = cardImages[1];
        cardIllust = GetComponentInChildren<RawImage>();

        CardDictionary.GetCardUIAddress(card.type, out string backPath, out string framePath);
        Addressables.LoadAssetAsync<Sprite>(backPath).Completed += ChangeBack;
        Addressables.LoadAssetAsync<Sprite>(framePath).Completed += ChangeFrame;
        Addressables.LoadAssetAsync<Texture2D>(card.illuPath).Completed += ChangeIllust;


        void ChangeIllust(AsyncOperationHandle<Texture2D> op)
        {
            if (op.Result == null)
            {
                Debug.LogError("no sprites here.");
                return;
            }
            cardIllust.texture = op.Result;
        }
        void ChangeBack(AsyncOperationHandle<Sprite> op)
        {
            if (op.Result == null)
            {
                Debug.LogError("no sprites here.");
                return;
            }
            backImg.sprite = op.Result;
        }
        void ChangeFrame(AsyncOperationHandle<Sprite> op)
        {
            if (op.Result == null)
            {
                Debug.LogError("no sprites here.");
                return;
            }
            frameImg.sprite = op.Result;
        }
    }
}
