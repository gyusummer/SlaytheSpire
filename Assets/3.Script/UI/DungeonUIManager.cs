using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUIManager : Singleton<DungeonUIManager>
{
    //public AbstractPlayerCharacter Player;
    public GameObject MapPanel;
    public GameObject DeckPanel;
    public GameObject DeckUI;
    public GameObject DrawPileUI;
    public GameObject DiscardPileUI;
    public Text playerHp;
    public Text playerMoney;
    public Text deckCount;
    public Text drawCount;
    public Text discardCount;
    public GameObject[] CardArrow;
    public GameObject ArrowMiddle;
    public GameObject ArrowEnd;

    int arrowNum = 15;
    private void Start()
    {
        Player.Instance.OnHpChanged += UpdatePlayerHp;
        Player.Instance.OnMoneyChanged += UpdatePlayerMoney;
        Player.Instance.OnCardPileChenged += UpdatePlayerCardCount;
        UpdatePlayerMoney();
        CardArrow = new GameObject[arrowNum];
        for(int n = 0; n < arrowNum; n++)
        {
            if (n != arrowNum - 1)
            {
                CardArrow[n] = Instantiate(ArrowMiddle, transform);
            }
            else
            {
                CardArrow[n] = Instantiate(ArrowEnd, transform);
            }
            CardArrow[n].SetActive(false);
        }
    }
    public void StartTarget(AbstractCard card)
    {
        StartCoroutine(DrawArrowPointer(card));
    }

    IEnumerator DrawArrowPointer(AbstractCard card)
    {
        foreach (GameObject arrow in CardArrow)
        {
            arrow.SetActive(true);
        }
        while (Player.Instance.selectedCard == card)
        {
            Vector2 startP = card.transform.position;
            Vector2 endP = Input.mousePosition;
            Vector2 midP = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
            float t = 1f / (arrowNum - 1);
            for (int n = 0; n < arrowNum; n++)
            {
                Vector3 point = Utils.BezierPoint(startP, midP, endP, t * n);
                CardArrow[n].transform.position = point;
                if (n != 0) 
                {
                    Utils.RotateObjectToward(CardArrow[n - 1], CardArrow[n]);
                }
                if(n == arrowNum - 1)
                {
                    Vector2 v = endP - (Vector2)CardArrow[n-1].transform.position;
                    float angle = Vector2.SignedAngle(Vector2.up, v);
                    CardArrow[n].transform.rotation = Quaternion.Euler(0,0,angle);
                }
            }
            yield return null;
        }
        foreach(GameObject arrow in CardArrow)
        {
            arrow.SetActive(false);
        }
    }
    public void ToggleMap()
    {
        if (MapPanel.activeSelf)
        {
            MapPanel.SetActive(false);
        }
        else
        {
            DeckPanel.SetActive(false);
            MapPanel.SetActive(true);
        }
        //MapPanel.SetActive(!MapPanel.activeSelf);
    }
    public void ToggleDeck(string cardPile)
    {
        if (DeckPanel.activeSelf && DeckUI.activeSelf)
        {
            DeckPanel.SetActive(false);
        }
        else
        {
            MapPanel.SetActive(false);
            DeckPanel.SetActive(true);
            ChooseCardPile(cardPile);
        }
        //DeckPanel.SetActive(!DeckPanel.activeSelf);
    }
    void ChooseCardPile(string cardPile)
    {
        switch (cardPile)
        {
            case "Deck":
                DeckUI.SetActive(true);
                DrawPileUI.SetActive(false);
                DiscardPileUI.SetActive(false);
                break;
            case "DrawPile":
                DeckUI.SetActive(false);
                DrawPileUI.SetActive(true);
                DiscardPileUI.SetActive(false);
                break;
            case "DiscardPile":
                DeckUI.SetActive(false);
                DrawPileUI.SetActive(false);
                DiscardPileUI.SetActive(true);
                break;
        }
    }
    public void UpdatePlayerHp()
    {
        playerHp.text = $"{Player.Instance.CurHp}/{Player.Instance.MaxHp}";
    }
    public void UpdatePlayerMoney()
    {
        playerMoney.text = Player.Instance.Money.ToString();
    }
    public void UpdatePlayerCardCount()
    {
        deckCount.text = Player.Instance.Deck.Count.ToString();
        drawCount.text = Player.Instance.DrawPile.Count.ToString();
        discardCount.text = Player.Instance.DiscardPile.Count.ToString();
    }
}
