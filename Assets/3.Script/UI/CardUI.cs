using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    Card card;
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
    bool isInHand = false;
    Vector2 defaultSize = Vector2.one * 0.45f;
    Vector2 handSize;
    Vector2 resPos;
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
        transform.localScale = defaultSize;
        handSize = defaultSize * 0.75f;
    }
    public void OnPointerEnter(PointerEventData e)
    {
        if (isInHand && Player.Instance.selectedCard == null)
        {
            resPos = transform.position;
            transform.localScale = defaultSize;
            transform.position += new Vector3(0, 100, 0);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isInHand && Player.Instance.selectedCard == null)
        {
            BackToHandPanel();
        }
    }
    public void BackToHandPanel()
    {
        transform.localScale = handSize;
        transform.position = resPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isInHand && Player.Instance.selectedCard == null)
        {
            if (card.cost <= Player.Instance.CurEnergy)
            {
                Player.Instance.selectedCard = card;
                if (card.targetType == TargetTypes.Single)
                {
                    DungeonUIManager.Instance.StartTarget(card);
                }
                else
                {
                    StartCoroutine(HoldingCard());
                }
            }
        }
    }
    public IEnumerator HoldingCard()
    {
        while (Player.Instance.selectedCard == card)
        {
            transform.position = Input.mousePosition;
            yield return null;
        }
        transform.position = resPos;
    }

    public void SetParent(Transform newParent)
    {
        //Debug.Log("카드UI의 SetParent");
        transform.SetParent(newParent);
        if (newParent.name.Contains("Hand"))
        {
            transform.localScale = handSize;
            isInHand = true;
        }
        else
        {
            transform.localScale = defaultSize;
            isInHand = false;
        }
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
