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
    DungeonUIManager ui;
    Image[] cardImages;
    RawImage cardIllust;
    Text descriptT;
    Text typeT;
    Text nameT;
    Text costT;
    private void Start()
    {
        ui = FindAnyObjectByType<DungeonUIManager>();
        transform.SetParent(ui.transform, false);
        if (TryGetComponent(out card))
        {
            cardImages = GetComponentsInChildren<Image>();
            cardIllust = GetComponentInChildren<RawImage>();
            ChangeImages();
            
            Text[] textBoxes = GetComponentsInChildren<Text>();
            descriptT = textBoxes[0];
            typeT = textBoxes[1];
            nameT = textBoxes[2];
            costT = textBoxes[3];
            descriptT.text = card.description;
            typeT.text = Enum.GetName(typeof(CardTypes), card.type);
            nameT.text = card.name;
            costT.text = card.cost.ToString();
        }
        gameObject.SetActive(false);
    }
    void ChangeImages()
    {
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
            cardImages[0].sprite = op.Result;
        }
        void ChangeFrame(AsyncOperationHandle<Sprite> op)
        {
            if (op.Result == null)
            {
                Debug.LogError("no sprites here.");
                return;
            }
            cardImages[1].sprite = op.Result;
        }
    }
}
